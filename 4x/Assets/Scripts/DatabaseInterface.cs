using UnityEngine;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DatabaseInterface : MonoBehaviour
{
    public DatabaseConnectionParams    connectionParams;

    [Header("Table Names")]
    public string tablePlanets = "GD_Planets";
    public string tableResources = "GD_Resources";

    public class Planet
    {
        public int      id;
        public string   name;
        public bool     playerOwned;
        public Vector2  position;
        public int      metal;
        public int      bio;
        public int      water;
    };

    SqlConnection connection;

    [HideInInspector] public List<Planet>  planets;
    float metal;
    float bio;
    float water;

    public static DatabaseInterface    instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public bool Connect()
    {
        if (connection != null) return true;

        string connectionString = "";

        connectionString += "Data Source=" + connectionParams.dataSource + ";";
        connectionString += "Initial Catalog=" + connectionParams.databaseName + ";";
        connectionString += "User ID=" + connectionParams.username + ";";
        connectionString += "Password=" + connectionParams.password + ";";

        connection = new SqlConnection(connectionString);
        try
        {
            Debug.Log("Connecting...");
            connection.Open();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to connect: " + e.Message);
            return false;
        }

        Debug.Log("Connection established!");

        return true;
    }

    public bool InitializeGame(int nPlanets)
    {
        if (!Connect()) return false;

        if (!CreateStructure()) return false;

        if (!CreatePlanets(nPlanets)) return false;

        if (!FetchData()) return false;

        SelectInitialPlanet();

        if (!FetchData()) return false;

        return true;
    }

    public bool FetchData()
    {
        if (!Connect()) return false;

        if (!FetchPlanets()) return false;
        if (!FetchResources()) return false;

        return true;
    }

    void ClearStructure()
    {
        RunQuery(string.Format("DROP TABLE {0}", tablePlanets));
        RunQuery(string.Format("DROP TABLE {0}", tableResources));
    }

    bool CreateStructure()
    {
        ClearStructure();

        if (!CreateStructurePlanets()) return false;
        if (!CreateStructureResources()) return false;

        return true;
    }

    bool CreateStructurePlanets()
    { 
        // Create planet structure
        string createPlanetQuery = "";
        createPlanetQuery += "CREATE TABLE " + tablePlanets + "(";
        createPlanetQuery += "  PlanetID INT NOT NULL PRIMARY KEY IDENTITY(1,1),";
        createPlanetQuery += "  Name VARCHAR(20) NOT NULL,";
        createPlanetQuery += "  PlayerOwned INT NOT NULL DEFAULT 0,";
        createPlanetQuery += "  PositionX INT NOT NULL,";
        createPlanetQuery += "  PositionY INT NOT NULL,";
        createPlanetQuery += "  Metal INT NOT NULL DEFAULT 0,";
        createPlanetQuery += "  Bio INT NOT NULL DEFAULT 0,";
        createPlanetQuery += "  Water INT NOT NULL DEFAULT 0,";
        createPlanetQuery += ");";

        return RunQuery(createPlanetQuery);
    }

    bool CreateStructureResources()
    {
        // Create planet structure
        string createResourcesQuery = "";
        createResourcesQuery += "CREATE TABLE " + tableResources + "(";
        createResourcesQuery += "  PlayerID INT NOT NULL PRIMARY KEY,";
        createResourcesQuery += "  Metal FLOAT NOT NULL DEFAULT 0,";
        createResourcesQuery += "  Bio FLOAT NOT NULL DEFAULT 0,";
        createResourcesQuery += "  Water FLOAT NOT NULL DEFAULT 0,";
        createResourcesQuery += ");";

        if (!RunQuery(createResourcesQuery)) return false;

        string sqlInsert = "INSERT INTO " + tableResources + " VALUES (1, 0, 0, 0)";

        if (!RunQuery(sqlInsert)) return false;

        return true;
    }

    bool CreatePlanets(int nPlanets)
    {
        for (int i = 0; i < nPlanets; i++)
        {
            string sqlInsert = "";
            sqlInsert += "INSERT INTO " + tablePlanets + " VALUES ('Planet " + (i + 1) + "',";  // Planet name
            sqlInsert += "0,";                                                                  // Planet owned
            sqlInsert += UnityEngine.Random.Range(-800, 800) + ",";                             // X Position
            sqlInsert += UnityEngine.Random.Range(-450, 350) + ",";                             // Y Position
            sqlInsert += UnityEngine.Random.Range(0, 100) + ",";                                // Metal
            sqlInsert += UnityEngine.Random.Range(0, 100) + ",";                                // Bio
            sqlInsert += UnityEngine.Random.Range(0, 100) + "";                                 // Water
            sqlInsert += ");";

            if (!RunQuery(sqlInsert)) return false;
        }

        return true;
    }

    bool RunQuery(string query)
    { 
        SqlCommand sql = new SqlCommand(query, connection);
        try
        {
            sql.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to run query: " + query);
            Debug.LogError("Error: " + e.Message);
            return false;
        }

        Debug.Log(query);

        return true;
    }

    bool RunQuery(string query, ref SqlDataReader reader)
    {       
        SqlCommand sql = new SqlCommand(query, connection);
        try
        {
            reader = sql.ExecuteReader();
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to run query: " + query);
            Debug.LogError("Error: " + e.Message);
            return false;
        }

        Debug.Log(query);

        return true;
    }

    bool FetchPlanets()
    {
        SqlDataReader dataReader = null;

        if (RunQuery(string.Format("SELECT * FROM {0}", tablePlanets), ref dataReader))
        {
            planets = new List<Planet>();
    
            while (dataReader.Read())
            {
                Planet planet = new Planet();
                planet.id = dataReader.GetInt32(dataReader.GetOrdinal("PlanetID"));
                planet.name = dataReader.GetString(dataReader.GetOrdinal("Name"));
                planet.playerOwned = (dataReader.GetInt32(dataReader.GetOrdinal("PlayerOwned")) == 0)?(false):(true);
                planet.position = new Vector2(dataReader.GetInt32(dataReader.GetOrdinal("PositionX")), dataReader.GetInt32(dataReader.GetOrdinal("PositionY")));
                planet.metal = dataReader.GetInt32(dataReader.GetOrdinal("Metal"));
                planet.bio = dataReader.GetInt32(dataReader.GetOrdinal("Bio"));
                planet.water  = dataReader.GetInt32(dataReader.GetOrdinal("Water"));

                planets.Add(planet);
            }
        }

        if (dataReader != null) dataReader.Close();

        return true;
    }

    bool FetchResources()
    {
        SqlDataReader dataReader = null;

        if (RunQuery(string.Format("SELECT * FROM {0} WHERE PlayerID = 1", tableResources), ref dataReader))
        {
            while (dataReader.Read())
            {
                metal = (float)dataReader.GetDouble(dataReader.GetOrdinal("Metal"));
                bio = (float)dataReader.GetDouble(dataReader.GetOrdinal("Bio"));
                water = (float)dataReader.GetDouble(dataReader.GetOrdinal("Water"));

                break;
            }
        }

        if (dataReader != null) dataReader.Close();

        return true;
    }

    bool SelectInitialPlanet()
    {
        int planetIndex = UnityEngine.Random.Range(0, planets.Count);
        int planetId = planets[planetIndex].id;

        return SetPlanetOwnedByPlayer(planetId, true);
    }

    bool SetPlanetOwnedByPlayer(int planetId, bool owned)
    {
        string updateQuery = string.Format("UPDATE {0} SET PlayerOwned = {1} WHERE PlanetID = {2}",
                                           tablePlanets,
                                           (owned) ? (1) : (0),
                                           planetId);

        if (!RunQuery(updateQuery)) return false;

        return true;
    }

    public void UpdateDatabase()
    {
    }

    public static int GetPlanetCount()
    {
        return instance.planets.Count;
    }

    public static Planet GetPlanetData(int id)
    {
        foreach (var planet in instance.planets)
        {
            if (planet.id == id) return planet;
        }
        return null;
    }

    public static int GetMetal()
    {
        return Mathf.FloorToInt(instance.metal);
    }

    public static int GetBio()
    {
        return Mathf.FloorToInt(instance.bio);
    }

    public static int GetWater()
    {
        return Mathf.FloorToInt(instance.water);
    }
}
