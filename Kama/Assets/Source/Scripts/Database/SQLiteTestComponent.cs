using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLiteTestComponent : MonoBehaviour
{
    IDbConnection DBConn = null;

    // Start is called before the first frame update
    void Start()
    {
        TestDB();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Connection()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/KAMA_Database";
        DBConn = new SqliteConnection(connection);
        DBConn.Open();
    }

    private void CreateTable()
    {
        IDbCommand DBcmd;
        IDataReader reader;

        DBcmd = DBConn.CreateCommand();
        string createGenres =
            "CREATE TABLE IF NOT EXISTS Genres (idGenre char(1) PRIMARY KEY, nameGenre varchar(6))";

        DBcmd.CommandText = createGenres;
        reader = DBcmd.ExecuteReader();
    }

    private void InsertInTable()
    {
        IDbCommand command = DBConn.CreateCommand();
        command.CommandText = "INSERT INTO Genres (idGenre, nameGenre) VALUES ('M','MALE')";
        command.ExecuteNonQuery();
        command.CommandText = "INSERT INTO Genres (idGenre, nameGenre) VALUES ('F','FEMALE')";
        command.ExecuteNonQuery();
    }

    private void TestDB()
    {
        Connection();
        CreateTable();
        InsertInTable();

        IDbCommand cmd_read = DBConn.CreateCommand();
        IDataReader reader;
        string query = "SELECT * FROM Genres";
        cmd_read.CommandText = query;
        reader = cmd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("name: " + reader[1].ToString());
        }

        DBConn.Close();
    }


}
