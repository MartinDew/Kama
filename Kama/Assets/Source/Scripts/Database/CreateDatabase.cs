using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class CreateDatabase : MonoBehaviour
{
    IDbConnection DBConn = null;
    string defaultStart = "CREATE TABLE IF NOT EXISTS ";

    private void Awake()
    {
        Connect();
    }
    private void Connect()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/KAMA_Database";
        DBConn = new SqliteConnection(connection);
        DBConn.Open();
    }

    private void CreateTableGenres()
    {
        try
        {
            IDbCommand CmdCreateTable;
            IDataReader reader;

            CmdCreateTable = DBConn.CreateCommand();

            string GenreTable = defaultStart +
                "Genres (idGenre char(1) PRIMARY KEY," +
                "nameGenre varchar(6))";

            CmdCreateTable.CommandText = GenreTable;
            reader = CmdCreateTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Genres not created");
        }
    }

    private void CreateTableClasses()
    {
        try
        {
            IDbCommand CmdCreateTable;
            IDataReader reader;

            CmdCreateTable = DBConn.CreateCommand();

            string ClassesTable = defaultStart +
                 "Classes (idClass char(3) PRIMARY KEY," +
                 "className varchar(16)," +
                 "startingHP number(3,0)," +
                 "startingMP number(3,0))";

            CmdCreateTable.CommandText = ClassesTable;
            reader = CmdCreateTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Classes not created");
        }
    }

    private void CreateTableWeapons()
    {
        try
        {
            IDbCommand CmdCreateTable;
            IDataReader reader;

            CmdCreateTable = DBConn.CreateCommand();

            string WeaponsTable = defaultStart +
                "Weapons (idWeapon number(3,0) PRIMARY KEY," +
                "nameWeapon varchar(28)," +
                "damagePoints number(3,0)," +
                "requiredLevel number(2,0)," +
                "MPUsage number(3,0)," +
                "requiredClassID char(3)," +
                "value number(3,0))";

            CmdCreateTable.CommandText = WeaponsTable;
            reader = CmdCreateTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Weapons not created");
        }
    }

    private void CreateTableArmor()
    {
        try
        {
            IDbCommand CmdCreateTable;
            IDataReader reader;

            CmdCreateTable = DBConn.CreateCommand();

            string ArmorTable = defaultStart +
               "Armor (idArmor number(3,0) PRIMARY KEY," +
               "defensePoints number(3,0)," +
               "requiredLevel number(2,0)," +
               "value number(3,0))";

            CmdCreateTable.CommandText = ArmorTable;
            reader = CmdCreateTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Armor not created");
        }
    }

    private void CreateTablePotions()
    {
        try
        {
            IDbCommand CmdCreateTable;
            IDataReader reader;

            CmdCreateTable = DBConn.CreateCommand();

            string PotionsTable = defaultStart +
                "Potions (idPotion number(3,0) PRIMARY KEY," +
                "typePotion varchar(12)," +
                "value number(3,0)," +
                "recoveryPoints number(3,0))";

            CmdCreateTable.CommandText = PotionsTable;
            reader = CmdCreateTable.ExecuteReader();
            Debug.Log("Potions created");
        }
        catch (Exception)
        {
            Debug.Log("Potions not created");
        }
    }

    private void DropAllTables()
    {
        try
        {
            IDbCommand dropTable;
            IDataReader reader;
            dropTable = DBConn.CreateCommand();
            string drop = "DROP TABLE Genres";
            dropTable.CommandText = drop;
            reader = dropTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Error dropping Genres");
        }

        try
        {
            IDbCommand dropTable;
            IDataReader reader;
            dropTable = DBConn.CreateCommand();
            string drop = "DROP TABLE Classes";
            dropTable.CommandText = drop;
            reader = dropTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Error dropping Classes");
        }

        try
        {
            IDbCommand dropTable;
            IDataReader reader;
            dropTable = DBConn.CreateCommand();
            string drop = "DROP TABLE Weapons";
            dropTable.CommandText = drop;
            reader = dropTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Error dropping Weapons");
        }

        try
        {
            IDbCommand dropTable;
            IDataReader reader;
            dropTable = DBConn.CreateCommand();
            string drop = "DROP TABLE Armor";
            dropTable.CommandText = drop;
            reader = dropTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Error dropping Armor");
        }

        try
        {
            IDbCommand dropTable;
            IDataReader reader;
            dropTable = DBConn.CreateCommand();
            string drop = "DROP TABLE Potions";
            dropTable.CommandText = drop;
            reader = dropTable.ExecuteReader();
        }
        catch (Exception)
        {
            Debug.Log("Error dropping Potions");
        }

    }

    private void InsertGenres()
    {
        IDbCommand cmd = DBConn.CreateCommand();
        cmd.CommandText = "INSERT INTO Genres (idGenre, nameGenre) values ('M','MALE')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "INSERT INTO Genres (idGenre, nameGenre) values ('F','FEMALE')";
        cmd.ExecuteNonQuery();
    }

    private void InsertClasses()
    {
        string defaultS = "INSERT INTO CLASSES (idClass, className, startingHP, startingMP) values ";
        IDbCommand cmd = DBConn.CreateCommand();
        cmd.CommandText = defaultS + "('KNI', 'Chevalier', 100, 100)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "('MAG', 'Mage', 70, 100)";
        cmd.ExecuteNonQuery();
    }

    private void InsertWeapons()
    {
        string defaultS = "INSERT INTO WEAPONS (idWeapon, nameWeapon, damagePoints, requiredLevel, MPUsage, requiredClassID, value) values ";
        IDbCommand cmd = DBConn.CreateCommand();
        // Knight weapons 
        cmd.CommandText = defaultS + "(1, 'Épée de bois', 30, 1, 5, 'KNI', 20')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(2, 'Épée de fer', 60, 3, 10, 'KNI', 45')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(3, 'Longue épée de fer', 85, 5, 20, 'KNI', 70')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(4, 'KAMA', 200, 10, 10, 'KNI', 500')";
        cmd.ExecuteNonQuery();
        // Mage weapons
        cmd.CommandText = defaultS + "(5, 'Baton de feu', 25, 1, 10, 'MAG', 30')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(6, 'Baton de vent', 50, 3, 20, 'MAG', 50')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(7, 'Baton de glace', 75, 5, 30, 'MAG', 75')";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(8, 'KAMA', 200, 10, 10, 'MAG', 300')";
        cmd.ExecuteNonQuery();
    }

    private void InsertArmor()
    {
        string defaultS = "INSERT INTO Armor (idArmor, defensePoints, requiredLevel, value) values ";
        IDbCommand cmd = DBConn.CreateCommand();
        cmd.CommandText = defaultS + "(1, 20, 1, 20)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(2, 30, 2, 30)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(3, 45, 3, 50)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(4, 60, 4, 60)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(5, 75, 5, 80)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(6, 100, 6, 100)";
        cmd.ExecuteNonQuery();
    }

    private void InsertPotions()
    {
        string defaultS = "INSERT INTO POTIONS (idPotion, typePotion, value, recoverypoints) values ";
        IDbCommand cmd = DBConn.CreateCommand();
        cmd.CommandText = defaultS + "(1, 'HPPotion', 10, 50)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(2, 'HPPotion', 20, 75)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(3, 'HPPotion', 30, 100)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(4, 'MPPotion', 10, 50)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(5, 'MPPotion', 20, 75)";
        cmd.ExecuteNonQuery();
        cmd.CommandText = defaultS + "(6, 'MPPotion', 30, 100)";
        cmd.ExecuteNonQuery();
    }

    private void testRead()
    {
        IDbCommand cmd_read = DBConn.CreateCommand();
        IDataReader reader;
        string query = "Select * from Potions";
        cmd_read.CommandText = query;
        reader = cmd_read.ExecuteReader();

        while (reader.Read())
        {
            Debug.Log("id:" + reader[0].ToString());
            Debug.Log("type:" + reader[1].ToString());
            Debug.Log("value:" + reader[2].ToString());
            Debug.Log("recovers:" + reader[3].ToString());
        }
        DBConn.Close();
    }
}
