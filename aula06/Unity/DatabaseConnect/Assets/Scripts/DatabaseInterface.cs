using UnityEngine;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DatabaseInterface : MonoBehaviour
{
    public string   dataSource;
    public string   databaseName;
    public string   username;
    public string   password;

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

    public static DatabaseInterface    Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool Connect()
    {
        if (connection != null) return true;

        string connectionString = "";

        connectionString += "Data Source=" + dataSource + ";";
        connectionString += "Initial Catalog=" + databaseName + ";";
        connectionString += "User ID=" + username + ";";
        connectionString += "Password=" + password + ";";

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

        if (!UpdateData()) return false;

        return true;
    }

    public bool UpdateData()
    {
        if (!Connect()) return false;

        if (!UpdatePlanets()) return false;

        return true;
    }

    void ClearStructure()
    {
        RunQuery("DROP TABLE Planets");
    }

    bool CreateStructure()
    {
        ClearStructure();

        // Create planet structure
        string createPlanetQuery = "";
        createPlanetQuery += "CREATE TABLE Planets (";
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


    bool CreatePlanets(int nPlanets)
    {
        for (int i = 0; i < nPlanets; i++)
        {
            string sqlInsert = "";
            sqlInsert += "INSERT INTO Planets VALUES ('Planet " + (i + 1) + "',";   // Planet name
            sqlInsert += "0,";                                                      // Planet owned
            sqlInsert += UnityEngine.Random.Range(-800, 800) + ",";                 // X Position
            sqlInsert += UnityEngine.Random.Range(-450, 450) + ",";                 // Y Position
            sqlInsert += UnityEngine.Random.Range(0, 100) + ",";                    // Metal
            sqlInsert += UnityEngine.Random.Range(0, 100) + ",";                    // Bio
            sqlInsert += UnityEngine.Random.Range(0, 100) + "";                     // Water
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

    bool UpdatePlanets()
    {
        SqlDataReader dataReader = null;

        if (RunQuery("SELECT * FROM Planets", ref dataReader))
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

        return true;
    }

    public static int GetPlanetCount()
    {
        return Instance.planets.Count;
    }

    public static Planet GetPlanetData(int id)
    {
        foreach (var planet in Instance.planets)
        {
            if (planet.id == id) return planet;
        }
        return null;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(DatabaseInterface))]
class DatabaseInterfaceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DatabaseInterface databaseInterface = (DatabaseInterface)target;

        EditorGUI.BeginChangeCheck();
        databaseInterface.dataSource = EditorGUILayout.TextField("Data Source", databaseInterface.dataSource);
        databaseInterface.databaseName = EditorGUILayout.TextField("Database", databaseInterface.databaseName);
        databaseInterface.username = EditorGUILayout.TextField("Username", databaseInterface.username);
        databaseInterface.password = EditorGUILayout.PasswordField("Data Source", databaseInterface.password);
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(databaseInterface);
        }
    }
}
#endif
