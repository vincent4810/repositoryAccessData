using MySql.Data.MySqlClient;
using Simplon.Data.Entity;

namespace Simplon.Data.Repository
{
    public class DogRepository
    {
        public List<Dog> FindAll()
        {
            var list = new List<Dog>();
            MySqlConnection? connection = null;
            try
            {

                connection = DBConnection.GetConnection();
                connection.Open();

                var request = new MySqlCommand("SELECT * FROM dog", connection);
                var result = request.ExecuteReader();

                while (result.Read())
                {
                    var dog = sqlToDog(result);
                    list.Add(dog);
                }

            } catch(MySqlException ex) {
                
                Console.WriteLine("DogRepository error : " + ex.Message);

            } finally {
                connection?.Close();
            }

            return list;
        }
        
        public Dog? Find(int id)
        {
           
            MySqlConnection? connection = null;
            try
            {

                connection = DBConnection.GetConnection();
                connection.Open();

                var request = new MySqlCommand("SELECT * FROM dog WHERE id=@id", connection);
                request.Parameters.AddWithValue("@id", id);
                var result = request.ExecuteReader();

                if (result.Read())
                {
                    Dog dog = sqlToDog(result);
                    return dog;
                }

            } catch(MySqlException ex) {
                
                Console.WriteLine("DogRepository error : " + ex.Message);

            } finally {
                connection?.Close();
            }

            return null;
        }


        public void Save(Dog dog)
        {
            
            MySqlConnection? connection = null;
            try
            {

                connection = DBConnection.GetConnection();

                connection.Open();

                var request = new MySqlCommand("INSERT INTO dog (name,breed,birth_date) VALUES (@name, @breed, @birthdate)", connection);
                request.Parameters.AddWithValue("@name", dog.Name);
                request.Parameters.AddWithValue("@breed", dog.Breed);
                request.Parameters.AddWithValue("@birthdate", dog.BirthDate);
                


                request.ExecuteNonQuery();
                dog.Id = (int?)request.LastInsertedId;
                

            } catch(MySqlException ex) {
                
                Console.WriteLine("DogRepository error : " + ex.Message);

            } finally {
                connection?.Close();
            }

            
        }

        public bool Update(Dog dog)
        {
            
            MySqlConnection? connection = null;
            try
            {

                connection = DBConnection.GetConnection();

                connection.Open();

                var request = new MySqlCommand("UPDATE dog SET name=@name,breed=@breed,birth_date=@birthdate WHERE id=@id", connection);
                request.Parameters.AddWithValue("@name", dog.Name);
                request.Parameters.AddWithValue("@breed", dog.Breed);
                request.Parameters.AddWithValue("@birthdate", dog.BirthDate);
                request.Parameters.AddWithValue("@id", dog.Id);
                
                if(request.ExecuteNonQuery() > 0){
                    return true;
                }

            } catch(MySqlException ex) {
                
                Console.WriteLine("DogRepository error : " + ex.Message);

            } finally {
                connection?.Close();
            }

            return false;
        }
        public bool Delete(Dog dog)
        {
            
            MySqlConnection? connection = null;
            try
            {

                connection = DBConnection.GetConnection();
                connection.Open();

                var request = new MySqlCommand("DELETE FROM dog WHERE id=@id", connection);
                request.Parameters.AddWithValue("@id", dog.Id);
                
                if(request.ExecuteNonQuery() > 0){
                    return true;
                }

            } catch(MySqlException ex) {
                
                Console.WriteLine("DogRepository error : " + ex.Message);

            } finally {
                connection?.Close();
            }

            return false;
        }
        
        private Dog sqlToDog(MySqlDataReader result)
        {
            return new Dog(result.GetString("name"), result.GetString("breed"), result.GetDateTime("birth_date"), result.GetInt32("id"));
        }
    }
}
