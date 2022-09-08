using System;
using System.Collections.Generic;
using Android.Util;
using androidcontrols.model;
using SQLite;

namespace androidcontrols.db
{
    public class AppDatabase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);



        public bool createDatabase()
        {
            try
            {
                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db"))) {

                    connect.CreateTable<Post>();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex",ex.Message);
                return false;
            }
        }

        //Insert Post to DB
        public bool insertPost(Post post)
        {
            try
            {

                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db")))
                {

                    connect.Insert(post);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex", ex.Message);
                return false;
            }
        }

        public List<Post> fetchAllPost()
        {
            try
            {
                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db")))
                {

                    
                    return connect.Table<Post>().ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex", ex.Message);
                return null;
            }
        }

        public List<Post> removePostById(string id)
        {
            try
            {
                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db")))
                {

                    return connect.Query<Post>("Delete from posts where userId=?",id);
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex", ex.Message);
                return null;
            }
        }

        public List<Post> UpdatePost(Post post)
        {
            try
            {
                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db")))
                {

                    return connect.Query<Post>("update posts set title=?, body=? where userId=?", post.title, post.body, post.userId);
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex", ex.Message);
                return null;
            }
        }
        
        
        public bool DeletePost(int userId)
        {
            try
            {
                using (var connect = new SQLiteConnection(System.IO.Path.Combine(folder, "AppDatabase.db")))
                {

                     connect.Delete<Post>(userId);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Info("AppDatabase Ex", ex.Message);
                return false;
            }
        }

        public AppDatabase()
        {
        }

        /*
         * 
         * private static AppDatabase instance = null;

        public static AppDatabase Instance()
        {
            if(instance == null)
            {
                instance = new AppDatabase();
            }
            return instance;
        }
        
         */


    }
}
