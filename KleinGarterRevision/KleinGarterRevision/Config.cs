using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace KleinGarterRevision
{
    public class Config
    {
        #region Default Data
        //Player attributes
        private const char DEF_PLAYER_SKIN = '\u25A0';
        private const int DEF_FOOD_CONSUMED = 50;
        private const int DEF_MIN_SPEED = 10;
        private const int DEF_MAX_SPEED = 40;

        //Level attributes
        private const char DEF_BORDER = '\u2588';
        private const int DEF_BORDER_COLOR = 1;
        private const int DEF_BACKGROUND_COLOR = 1;
        private const int DEF_LEVEL_WIDTH = 50;
        private const int DEF_LEVEL_HEIGHT = 25;
        private const int DEF_LEVEL_DIFFICULTY = 1;
        #endregion

        //Name of .xml file
        public static string CONFIG_FNAME = "config.xml";

        public static ConfigData GetConfigData()
        {
            if (!File.Exists(CONFIG_FNAME)) //Creates config file with deault values
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Create))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                    ConfigData sxml = new ConfigData();
                    xs.Serialize(fs, sxml);
                    return sxml;
                }
            }
            else //Reads config from file
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                    ConfigData sc = (ConfigData)xs.Deserialize(fs);
                    return sc;
                }
            }
        }

        //Saves config data to file
        public static bool SaveConfigData(ConfigData config)
        {
            if (!File.Exists(CONFIG_FNAME)) return false;

            using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Truncate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ConfigData));
                xs.Serialize(fs, config);
                return true;
            }
        }

        //Stored config data
        public class ConfigData
        {
            //Player attributes
            public char PlayerSkin;
            public int FoodConsumed;
            public int MinSpeed;
            public int MaxSpeed;

            //Level attributes
            public char Border;
            public int LevelWidth;
            public int LevelHeight;
            public int LevelDifficulty;
            public int BorderColor;
            public int BackgroundColor;

            public ConfigData()
            {
                PlayerSkin = DEF_PLAYER_SKIN;
                FoodConsumed = DEF_FOOD_CONSUMED;
                MinSpeed = DEF_MIN_SPEED;
                MaxSpeed = DEF_MAX_SPEED;

                Border = DEF_BORDER;
                LevelWidth = DEF_LEVEL_WIDTH;
                LevelHeight = DEF_LEVEL_HEIGHT;
                LevelDifficulty = DEF_LEVEL_DIFFICULTY;
                BorderColor = DEF_BORDER_COLOR;
                BackgroundColor = DEF_BACKGROUND_COLOR;
            }
        }
    }
}
