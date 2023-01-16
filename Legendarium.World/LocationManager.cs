using System;
using static LegendariumWorld.Location;

namespace LegendariumWorld
{
    public class LocationManager
    {
        static string previousBiome = "";
        //OpenAIService openAiService = new OpenAIService(new OpenAiOptions()
        //{
        //    ApiKey = Environment.GetEnvironmentVariable("MY_OPEN_AI_API_KEY")
        //});

        // Creates a ring map - each new location wraps around the previous one. NOT YET, its missing the x1=0 to x2 range.
        public static List<Location> CreateLocations(Planet planet)
        {   
            List<Location> locations = new List<Location>();            

            var iterator = 0;
            var x = planet.Size;
            var y = planet.Size;
            var previousX = 0;
            var previousY = 0;

            do
            {
                Location location = new Location();

                var random = new Random();

                var xAmount = random.Next(1, 10);
                var yAmount = random.Next(1, 10);

                if (x - xAmount <= -1)
                {
                    do
                    {                        
                        xAmount -= 1;

                        if(y - yAmount != 0)
                        {
                            yAmount = y;
                        }
                    }
                    while(x - xAmount != 0);
                }
                if(y - yAmount <= -1)
                {
                    do
                    {
                        yAmount -= 1;
                        if (x - xAmount != 0)
                        {
                            xAmount = x;
                        }
                    }
                    while (y - yAmount != 0);
                }               

                location.CoordinateX2 = previousX + xAmount;
                location.CoordinateY2 = previousY + yAmount;

                if (iterator == 0)
                {
                    location.CoordinateX1 = 0;
                    location.CoordinateY1 = 0;
                    location.Size = xAmount * yAmount;
                    iterator++;
                }
                else
                {
                    if(x == 0)
                    {
                        location.CoordinateX1 = previousX + 1;
                        yAmount = y;                        
                    }
                    else if(y == 0)
                    {
                        location.CoordinateY1 = previousY + 1;
                        xAmount = x;
                    }
                    else
                    {
                        location.CoordinateX1 = previousX + 1;
                        location.CoordinateY1 = /*previousY + 1*/0;                        
                    }
                }

                location.Size = (location.CoordinateX2 - location.CoordinateX1) * (location.CoordinateY2 - location.CoordinateY1);
                if(location.CoordinateX2 - location.CoordinateX1 == 0 || location.CoordinateY2 - location.CoordinateY1 == 0)
                {
                    location.Size = (location.CoordinateX2 - location.CoordinateX1) + (location.CoordinateY2 - location.CoordinateY1);
                }

  
                // Keep track of how much of the total planet size has been assigned to a direction
                previousX += xAmount;
                previousY += yAmount;

                // Minus the total amount from the planet size.
                x -= xAmount;
                y -= yAmount;

                if (previousBiome == "")
                {
                    location.Biome = GetRandomBiome("First");
                }
                else
                {
                    location.Biome = GetRandomBiome(previousBiome);
                }
                
                previousBiome = location.Biome;
                location.Name = GetRandomLocationName();
                location.IsOnSurface = GetIsSurfaceLevel(location);
                location.PlanetId = planet.Id;
                location.Type = "Surface Level";                

                locations.Add(location);

            }
            while(y > 0 || x > 0);

            return locations;

        }

        public static List<GameMapItem> CreateGameMapItems(Location location)
        {
            List<GameMapItem> gameMapItems = new List<GameMapItem>();

            var yRange = (location.CoordinateY2 - location.CoordinateY1) + 1;
            var xRange = (location.CoordinateX2 - location.CoordinateX1) + 1;

            // create a loop that enumerates every possible game coordinate
            for(int iy = 0; iy < yRange; iy++)
            {
                // No map locations on 0;
                if (location.CoordinateY1 == 0 && iy == 0)
                {
                    iy = 1;
                }

                for (int ix = 0; ix < xRange; ix++)
                {

                    // No map locations on 0;
                    if(location.CoordinateX1 == 0 && ix == 0)
                    {
                        ix = 1;
                    }
                    GameMapItem gameMap = new GameMapItem()
                    {
                        X = location.CoordinateX1 + ix,
                        Y = location.CoordinateY1 + iy,
                        Z = 1,
                        PowerLevel = new Random().Next(1, 100)
                    };

                    switch (location.Biome)
                    {
                        case "Forest":
                            {
                                // Forest Creation Parameters
                                gameMap.Type = SelectRandomTileType("Forest");
                                break;
                            }
                        case "Desert":
                            {
                                // Desert Creation Parameters                                                               
                                gameMap.Type = SelectRandomTileType("Desert");
                                if(gameMap.Type == "Dune")
                                {
                                    gameMap.IsTileMoveable = true;
                                }
                                
                                break;
                            }
                        case "Grasslands":
                            {
                                // Grasslands Creation Parameters
                                gameMap.Type = SelectRandomTileType("Grasslands");
                                break;
                            }
                        case "Mountain":
                            {
                                gameMap.Type = SelectRandomTileType("Mountain");
                                break;
                            }
                        case "Hills":
                            {
                                gameMap.Type = SelectRandomTileType("Hills");
                                break;
                            }
                        case "Valley":
                            {
                                gameMap.Type = SelectRandomTileType("Valley");
                                break;
                            }
                        case "Highlands":
                            {
                                gameMap.Type = SelectRandomTileType("Highlands");
                                break;
                            }
                        case "Plateau":
                            {
                                gameMap.Type = SelectRandomTileType("Plateau");
                                break;
                            }
                        case "BadLands":
                            {
                                gameMap.Type = SelectRandomTileType("BadLands");
                                break;
                            }
                        case "Arctic":
                            {
                                gameMap.Type = SelectRandomTileType("Arctic");
                                break;
                            }
                        case "Swamp":
                            {
                                gameMap.Type = SelectRandomTileType("Swamp");
                                break;
                            }
                        case "Jungle":
                            {
                                gameMap.Type = SelectRandomTileType("Jungle");
                                break;
                            }
                        case "Volcanic":
                            {
                                gameMap.Type = SelectRandomTileType("Volcanic");
                                break;
                            }
                        case "Ocean":
                            {
                                gameMap.Type = SelectRandomTileType("Ocean");
                                break;
                            }
                        case "Riverlands":
                            {
                                gameMap.Type = SelectRandomTileType("Riverlands");
                                break;
                            }
                        case "Tropical":
                            {
                                gameMap.Type = SelectRandomTileType("Tropical");
                                break;
                            }
                        case "Underground":
                            {
                                gameMap.Type = SelectRandomTileType("Underground");
                                break;
                            }


                    }
                    gameMap.ParentLocationId = location.Id;
                    gameMapItems.Add(gameMap);
                }
            }

            return gameMapItems;

        }

        public static List<Resource> CreateResources(List<GameMapItem> gameMapItems)
        {
            var resources = new List<Resource>();
            foreach(GameMapItem gameMap in gameMapItems)
            {
                var resource = new Resource();


                var attributes = 0;

                switch (gameMap.PowerLevel)
                {
                    case >= 90:
                        {
                            // 4 roles @ 90% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 4; i++)
                            {
                                if (Roll(90))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 80:
                        {
                            // 3 roles @ 80% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 3; i++)
                            {
                                if (Roll(80))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 70:
                        {
                            // 3 roles @ 70% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 3; i++)
                            {
                                if (Roll(70))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 50:
                        {
                            // 3 roles @ 50% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 3; i++)
                            {
                                if (Roll(50))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 40:
                        {
                            // 2 roles @ 40% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 2; i++)
                            {
                                if (Roll(40))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 30:
                        {
                            // 2 roles @ 30% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 2; i++)
                            {
                                if (Roll(30))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 20:
                        {
                            // 2 roles @ 20% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 2; i++)
                            {
                                if (Roll(20))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 10:
                        {
                            // 2 role @ 10% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 2; i++)
                            {
                                if (Roll(10))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                    case >= 1:
                        {
                            // 1 role @ 10% to acquire an attribute to attach to the resource.
                            for (int i = 0; i < 1; i++)
                            {
                                if (Roll(10))
                                {
                                    attributes++;
                                }
                            }

                            resource = AssignResourceAttributes(attributes);
                            resource.Type = AssignResourceType();
                            resource.Amount = 1000;
                            resource.X = gameMap.X;
                            resource.Y = gameMap.Y;
                            resource.Z = gameMap.Z;
                            resources.Add(resource);
                            break;
                        }
                }
            }
            return resources;
        }

        private static string AssignResourceType()
        {
            var random = new Random();

            var resourceType = new string[]
            {
                "Stone",
                "Clay",
                "Metal",
                "Mineral",
                "Crystal",
                "Wood"
            };

            var type = resourceType[random.Next(0, resourceType.Length)];

            return type;
        }

        private static Resource AssignResourceAttributes(int amount)
        {
            var resource = new Resource();
            var random = new Random();

            var attributes = new string[]
            {
                "HP",
                "Armor",
                "Strength",
                "Agility",
                "Intellect",
                "Dialect",
                "Discernment",
                "Stamina",
                "Dexterity",
                "Attack",
                "Defense",
                "Energy",
                "Power",
                "Vision",
                "Damage",
                "Magic",
                "Fire",
                "Ice",
                "Cosmic",
                "Water",
                "Creative",
                "Plenty",
                "Red",
                "Green",
                "Blue",
                "Azure",
                "Feather",
                "Purple",
                "Toxic",
                "Vitality",
                "Volatile",
                "Thorn",
                "Dark",
                "Light",
                "Magnetic",
                "Air",
                "Dread",
                "Buoyant",
                "Amphibious",
                "Wandering", // Floats in air.
                "Ethereal"
            };

            if(amount == 4)
            {
                resource.Attribute1 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute2 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute3 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute4 = attributes[random.Next(0, attributes.Length)];
            }
            if (amount == 3)
            {
                resource.Attribute1 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute2 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute3 = attributes[random.Next(0, attributes.Length)];
            }
            if (amount == 2)
            {
                resource.Attribute1 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute2 = attributes[random.Next(0, attributes.Length)];
            }
            if (amount == 1)
            {
                resource.Attribute1 = attributes[random.Next(0, attributes.Length)];
                resource.Attribute2 = attributes[random.Next(0, attributes.Length)];
            }

            return resource;
        }

        private static bool Roll(int chance)
        {
            int roll = new Random().Next(1, 100);
            if(roll <= chance)
            {
                return true;
            }
            return false;
        }

        private static string SelectRandomTileType(string biome)
        {
            var random = new Random();
            var rarity = random.Next(1, 100);

            switch (biome)
            {
                case "Desert":
                    {
                        var tileType = new string[]
                        {
                            "Sand",
                            "Dune",
                            "Oasis"
                        };

                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[2];
                        }

                        if (rarity > 10 && rarity <= 50)
                        {
                            return tileType[1];
                        }

                        if (rarity > 50 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];                        
                    }
                case "Forest":
                    {
                        var tileType = new string[]
                        {
                            "Forest",
                            "Meadow",
                            "Hill",
                            "Gully",
                            "Lake",
                            "Rocky",
                            "Mountain",                            
                            "Valley"
                        };

                        if (rarity == 1)
                        {
                            return tileType[7];
                        }

                        if (rarity > 1 && rarity <= 4)
                        {
                            return tileType[6];
                        }

                        if (rarity >= 5 && rarity <= 10)
                        {
                            return tileType[5];
                        }

                        if(rarity > 10 && rarity <= 15)
                        {
                            return tileType[4];
                        }

                        if (rarity > 15 && rarity <= 20)
                        {
                            return tileType[3];
                        }

                        if (rarity > 20 && rarity <= 40)
                        {
                            return tileType[2];
                        }

                        if (rarity > 40 && rarity <= 50)
                        {
                            return tileType[1];
                        }

                        if (rarity > 50 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }

                case "Jungle":
                    {
                        var tileType = new string[]
                        {
                            "Jungle",
                            "Dense",
                            "Tangled",
                            "Lagoon",
                            "Waterfall",
                            "Hill",
                            "Mountain",
                            "Beach",
                            "Rocky"
                        };

                        if (rarity > 0 && rarity <= 4)
                        {
                            return tileType[8];
                        }
                        if (rarity > 4 && rarity <= 5)
                        {
                            return tileType[7];
                        }
                        if (rarity > 5 && rarity <= 8)
                        {
                            return tileType[6];
                        }
                        if (rarity > 8 && rarity <= 15)
                        {
                            return tileType[5];
                        }
                        if (rarity > 15 && rarity <= 20)
                        {
                            return tileType[4];
                        }
                        if (rarity > 20 && rarity <= 22)
                        {
                            return tileType[3];
                        }
                        if (rarity > 22 && rarity <= 50)
                        {
                            return tileType[2];
                        }
                        if (rarity > 50 && rarity <= 70)
                        {
                            return tileType[1];
                        }
                        if (rarity > 70 && rarity <= 100)
                        {
                            return tileType[0];
                        }
                        return tileType[0];
                    }
                case "Grasslands":
                    {
                        var tileType = new string[]
                        {
                            "Grasslands",
                            "Grassy",
                            "Gully",
                            "Hills",
                            "Savanna",
                            "Shruburb"
                        };

                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[5];
                        }

                        if (rarity > 10 && rarity <= 15)
                        {
                            return tileType[4];
                        }

                        if (rarity > 15 && rarity <= 25)
                        {
                            return tileType[3];
                        }
                        if (rarity > 25 && rarity <= 35)
                        {
                            return tileType[2];
                        }
                        if (rarity > 35 && rarity <= 50)
                        {
                            return tileType[1];
                        }
                        if (rarity > 50 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Mountain":
                    {
                        var tileType = new string[]
                        {
                            "Mountain",
                            "Rocky",
                            "Precipice",
                            "Ridge",
                            "Bluff",
                            "Scar",
                            "Steep",
                            "Stone",
                            "Highland",
                            "Plateau"
                        };

                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[9];
                        }
                        if (rarity > 10 && rarity <= 20)
                        {
                            return tileType[8];
                        }
                        if (rarity > 20 && rarity <= 23)
                        {
                            return tileType[7];
                        }
                        if (rarity > 23 && rarity <= 30)
                        {
                            return tileType[6];
                        }
                        if (rarity > 30 && rarity <= 50)
                        {
                            return tileType[5];
                        }
                        if (rarity > 50 && rarity <= 60)
                        {
                            return tileType[4];
                        }
                        if (rarity > 60 && rarity <= 70)
                        {
                            return tileType[3];
                        }
                        if (rarity > 70 && rarity <= 90)
                        {
                            return tileType[2];
                        }
                        if (rarity > 90 && rarity <= 95)
                        {
                            return tileType[1];
                        }
                        if (rarity > 95 && rarity <= 100)
                        {
                            return tileType[0];
                        }
                        return tileType[0];
                    }
                case "Hills":
                    {
                        var tileType = new string[]
                        {
                            "Hill",
                            "Hummock",
                            "Mound",
                            "Knoll",
                            "Downs",
                            "Drumlin",// Good for clay, perhaps all Hill types are good for minerals, metals
                            "Highland",
                            "Plateau"
                        };

                        if (rarity > 0 && rarity <= 5)
                        {
                            return tileType[7];
                        }

                        if (rarity > 5 && rarity <= 10)
                        {
                            return tileType[6];
                        }

                        if (rarity > 10 && rarity <= 20)
                        {
                            return tileType[5];
                        }
                        if (rarity > 20 && rarity <= 25)
                        {
                            return tileType[4];
                        }
                        if (rarity > 25 && rarity <= 35)
                        {
                            return tileType[3];
                        }
                        if (rarity > 35 && rarity <= 50)
                        {
                            return tileType[2];
                        }
                        if (rarity > 50 && rarity <= 60)
                        {
                            return tileType[1];
                        }
                        if (rarity > 60 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Valley":
                    {
                        var tileType = new string[]
                        {
                            "Valley",
                            "Ridge",
                            "Mountain",
                            "Rocky",
                            "Forest",
                            "Lake",
                            "Gorge",
                            "Basin",
                            "Canyon",
                            "Hole",
                            "Dale",
                            "Vale" // 100% chance to get a river.
                        };

                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[11];
                        }

                        if (rarity > 10 && rarity <= 15)
                        {
                            return tileType[10];
                        }

                        if (rarity > 15 && rarity <= 16)
                        {
                            return tileType[9];
                        }
                        if (rarity > 16 && rarity <= 21)
                        {
                            return tileType[8];
                        }
                        if (rarity > 21 && rarity <= 25)
                        {
                            return tileType[7];
                        }
                        if (rarity > 25 && rarity <= 33)
                        {
                            return tileType[6];
                        }
                        if (rarity > 33 && rarity <= 40)
                        {
                            return tileType[5];
                        }
                        if (rarity > 40 && rarity <= 50)
                        {
                            return tileType[4];
                        }
                        if (rarity > 50 && rarity <= 60)
                        {
                            return tileType[3];
                        }
                        if (rarity > 60 && rarity <= 70)
                        {
                            return tileType[2];
                        }
                        if (rarity > 70 && rarity <= 80)
                        {
                            return tileType[1];
                        }
                        if (rarity > 80 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "BadLands":
                    {
                        var tileType = new string[]
                        {
                            "BandLand",
                            "Rocky",
                            "Hill",
                            "Gully",
                            "Canyon",
                            "Ravine",
                            "Hoodoo"
                        };

                        if (rarity > 0 && rarity <= 5)
                        {
                            return tileType[6];
                        }
                        if (rarity > 5 && rarity <= 15)
                        {
                            return tileType[5];
                        }
                        if (rarity > 15 && rarity <= 25)
                        {
                            return tileType[4];
                        }
                        if (rarity > 25 && rarity <= 35)
                        {
                            return tileType[3];
                        }
                        if (rarity > 35 && rarity <= 45)
                        {
                            return tileType[2];
                        }
                        if (rarity > 45 && rarity <= 55)
                        {
                            return tileType[1];
                        }
                        if (rarity > 55 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Arctic":
                    {
                        var tileType = new string[]
                        {
                            "Arctic",
                            "Snow",
                            "Ice",
                            "Tundra",
                            "Frozen Lake",
                            "Glacier",
                            "Mountain",
                            "Hill",
                            "Rocky"
                        };
                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[8];
                        }
                        if (rarity > 10 && rarity <= 15)
                        {
                            return tileType[7];
                        }
                        if (rarity > 15 && rarity <= 20)
                        {
                            return tileType[6];
                        }
                        if (rarity > 20 && rarity <= 30)
                        {
                            return tileType[5];
                        }
                        if (rarity > 30 && rarity <= 33)
                        {
                            return tileType[4];
                        }
                        if (rarity > 33 && rarity <= 40)
                        {
                            return tileType[3];
                        }
                        if (rarity > 40 && rarity <= 60)
                        {
                            return tileType[2];
                        }
                        if (rarity > 60 && rarity <= 80)
                        {
                            return tileType[1];
                        }
                        if (rarity > 80 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Swamp":
                    {
                        var tileType = new string[]
                        {
                            "Swamp",
                            "Forest",
                            "Bog",
                            "Fen",
                            "Muskeg",
                            "Marsh"

                        };
                        
                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[5];
                        }
                        if (rarity > 10 && rarity <= 20)
                        {
                            return tileType[4];
                        }
                        if (rarity > 20 && rarity <= 25)
                        {
                            return tileType[3];
                        }
                        if (rarity > 25 && rarity <= 35)
                        {
                            return tileType[2];
                        }
                        if (rarity > 35 && rarity <= 45)
                        {
                            return tileType[1];
                        }
                        if (rarity > 45 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Volcanic":
                    {
                        var tileType = new string[]
                        {
                            "Volcanic",
                            "Rocky",
                            "Mountain",
                            "Barren"
                        };

                        if (rarity > 0 && rarity <= 20)
                        {
                            return tileType[3];
                        }
                        if (rarity > 20 && rarity <= 30)
                        {
                            return tileType[2];
                        }
                        if (rarity > 30 && rarity <= 50)
                        {
                            return tileType[1];
                        }
                        if (rarity > 50 && rarity <= 100)
                        {
                            return tileType[0];
                        }
                        return tileType[0];
                    }
                case "Oceania":
                    {
                        var tileType = new string[]
                        {
                            "Ocean",
                            "Iceburg",
                            "Coral Reef",
                            "Island",
                            "Whirlpool",
                            "The Deep",
                            "Land"
                        };

                        if (rarity > 0 && rarity <= 10)
                        {
                            return tileType[6];
                        }

                        if (rarity > 10 && rarity <= 30)
                        {
                            return tileType[5];
                        }

                        if (rarity > 30 && rarity <= 31)
                        {
                            return tileType[4];
                        }
                        if (rarity > 31 && rarity <= 55)
                        {
                            return tileType[3];
                        }
                        if (rarity > 55 && rarity <= 65)
                        {
                            return tileType[2];
                        }
                        if (rarity > 65 && rarity <= 70)
                        {
                            return tileType[1];
                        }
                        if (rarity > 70 && rarity <= 100)
                        {
                            return tileType[0];
                        }

                        return tileType[0];
                    }
                case "Riverlands":
                    {
                        var tileType = new string[]
                        {
                            "Plain",
                            "Forest",
                            "Hill",
                            "Swamp",
                            "Lake"
                        };

                        if (rarity > 0 && rarity <= 22)
                        {
                            return tileType[4];
                        }

                        if (rarity > 22 && rarity <= 44)
                        {
                            return tileType[3];
                        }
                        if (rarity > 44 && rarity <= 66)
                        {
                            return tileType[2];
                        }
                        if (rarity > 66 && rarity <= 78)
                        {
                            return tileType[1];
                        }
                        if (rarity > 78 && rarity <= 100)
                        {
                            return tileType[0];
                        }
                        return tileType[0];
                    }

                case "Tropical":
                    {
                        var tileType = new string[]
                        {
                            "Tropical",
                            "Rainforest",
                            "Hill",
                            "Mountain",
                            "Swamp",
                            "Pool"
                        };

                        if (rarity > 0 && rarity <= 5)
                        {
                            return tileType[5];
                        }

                        if (rarity > 5 && rarity <= 10)
                        {
                            return tileType[4];
                        }

                        if (rarity > 10 && rarity <= 13)
                        {
                            return tileType[3];
                        }
                        if (rarity > 13 && rarity <= 25)
                        {
                            return tileType[2];
                        }
                        if (rarity > 25 && rarity <= 50)
                        {
                            return tileType[1];
                        }
                        if (rarity > 50 && rarity <= 100)
                        {
                            return tileType[0];
                        }
                        return tileType[0];
                    }
            }
            return null;
        }

        private static int GetWood(int chance)
        {
            var random = new Random();

            if(random.Next(1,100) < chance)
            {
                return random.Next(1,100);
            }

            return 0;
        }

        private static int GetTerrainSpeedPenalty(string biome)
        {
            switch (biome)
            {
                case "Forest":
                    {
                        return 10;   
                    }

                default:
                    return 0;
            }
        }

            // Creates a square bordering the top left of the previous square.

            //public static List<Location> CreateLocations(Planet planet)
            //{
            //    List<Location> locations = new List<Location>();

            //    var iterator = 0;
            //    var x = planet.Size;
            //    var y = planet.Size;
            //    var previousX = 0;
            //    var previousY = 0;

            //    do
            //    {
            //        Location location = new Location();

            //        var random = new Random();

            //        var xAmount = random.Next(1, 10);
            //        var yAmount = random.Next(1, 10);

            //        if (x - xAmount <= -1)
            //        {
            //            do
            //            {
            //                xAmount -= 1;

            //                if (y - yAmount != 0)
            //                {
            //                    yAmount = y;
            //                }
            //            }
            //            while (x - xAmount != 0);
            //        }
            //        if (y - yAmount <= -1)
            //        {
            //            do
            //            {
            //                yAmount -= 1;
            //                if (x - xAmount != 0)
            //                {
            //                    xAmount = x;
            //                }
            //            }
            //            while (y - yAmount != 0);
            //        }

            //        location.CoordinateX2 = previousX + xAmount;
            //        location.CoordinateY2 = previousY + yAmount;

            //        if (iterator == 0)
            //        {
            //            location.CoordinateX1 = 0;
            //            location.CoordinateY1 = 0;
            //            location.Size = xAmount * yAmount;
            //            iterator++;
            //        }
            //        else
            //        {
            //            if (x == 0)
            //            {
            //                location.CoordinateX1 = previousX + 1;
            //                yAmount = y;
            //            }
            //            else if (y == 0)
            //            {
            //                location.CoordinateY1 = previousY + 1;
            //                xAmount = x;
            //            }
            //            else
            //            {
            //                location.CoordinateX1 = previousX + 1;
            //                location.CoordinateY1 = previousY + 1;
            //            }
            //        }

            //        location.Size = (location.CoordinateX2 - location.CoordinateX1) * (location.CoordinateY2 - location.CoordinateY1);
            //        if (location.CoordinateX2 - location.CoordinateX1 == 0 || location.CoordinateY2 - location.CoordinateY1 == 0)
            //        {
            //            location.Size = (location.CoordinateX2 - location.CoordinateX1) + (location.CoordinateY2 - location.CoordinateY1);
            //        }


            //        // Keep track of how much of the total planet size has been assigned to a location
            //        previousX += xAmount;
            //        previousY += yAmount;

            //        // Minus the total amount from the planet size.
            //        x -= xAmount;
            //        y -= yAmount;


            //        location.Biome = GetRandomBiome();
            //        location.Name = GetRandomLocationName();
            //        location.IsOnSurface = GetIsSurfaceLevel(location);
            //        location.PlanetId = planet.Id;
            //        location.Type = "Surface Level";

            //        locations.Add(location);

            //    }
            //    while (y > 0 || x > 0);

            //    return locations;

            //}

            public static Location CreateChildLocation(Location parentLocation, string type, int xCoordinate, int yCoordinate)
        {            
            var newLocation = new Location();

            newLocation.PlanetId = parentLocation.PlanetId;
            newLocation.ParentLocationId = parentLocation.Id;
            newLocation.Type = type;
            // This gets where the new location is overall on the map.
            newLocation.XCoordinate = xCoordinate;
            newLocation.YCoordinate = yCoordinate;

            switch (type)
            {
                case "Settlement":
                    newLocation.Biome = "Village";
                    newLocation.IsOnSurface = true;
                    newLocation.Size = 2;
                    newLocation.Name = "Thumos";
                    // This gives the new location space/range on the map and expands it out in the X and Y direction.
                    newLocation.CoordinateX1 = xCoordinate;
                    newLocation.CoordinateY1 = yCoordinate;
                    newLocation.CoordinateX2 = xCoordinate + newLocation.Size;
                    newLocation.CoordinateY2 = yCoordinate + newLocation.Size;
                    break;

                case "Building":                    
                    newLocation.Type = "Building";
                    newLocation.Biome = "Wooden Interior";
                    newLocation.XCoordinate = xCoordinate;
                    newLocation.YCoordinate = yCoordinate;
                    newLocation.Size = 1;
                    newLocation.IsOnSurface = true;
                    newLocation.Name = "Basic Shelter";
                    newLocation.CoordinateX1 = xCoordinate;
                    newLocation.CoordinateY1 = yCoordinate;
                    newLocation.CoordinateX2 = xCoordinate + newLocation.Size;
                    newLocation.CoordinateY2 = yCoordinate + newLocation.Size;
                    break;
            }
            return newLocation;
        }

        public static Location CreateUnderGroundLocation(Location location)
        {
            var dungeon = new Location()
            {
                ParentLocationId = location.Id,
                Type = "Dungeon",
                Biome = GetRandomUnderGroundBiome(),
                XCoordinate = AssignLocationXCoordinates(1, 100), // assigning the X location of where this location will exist within the parent
                YCoordinate = AssignLocationYCoordinates(1, 100), // assigning the Y location of where this location will exist within the parent
                Size = 25,
                IsOnSurface = true,
                Name = "Basic Shelter"
            };

            // Create the X and Y size within the parent
            dungeon.CoordinateX2 = dungeon.XCoordinate + dungeon.Size;
            dungeon.CoordinateY2 = dungeon.YCoordinate + dungeon.Size;

            // X1 and Y1 will be the same as the start location of the X and Y coordinate
            dungeon.CoordinateX1 = dungeon.XCoordinate;
            dungeon.CoordinateY1 = dungeon.YCoordinate;

            return dungeon;
        }

        private static int AssignLocationXCoordinates(int x1, int x2)
        {
            var random = new Random();
            var x = random.Next() * (x2 - x1) + x1;
            
            return x;
        }

        private static int AssignLocationYCoordinates(int y1, int y2)
        {
            var random = new Random();
            var y = random.Next() * (y2 - y1) + y1;

            return y;
        }

        public static string GetRandomUnderGroundBiome()
        {
            var random = new Random();

            Type biomeType = typeof(UnderGroundBiomes);

            Array biomeValues = biomeType.GetEnumValues();

            var biomeName = (UnderGroundBiomes)random.Next(biomeValues.Length);

            return biomeName.ToString();
        }


        public static double GetRandomSize()
        {
            var random = new Random();
            var size = random.NextDouble() * (1000 - 0.01) + 0.01;
            var value = Math.Round(size, 2);

            return value;
        }


        public static int GetNewBiomeRNG()
        {
            var random = new Random();
    
            return random.Next(1, 100);
            
        }

        public static string GetRandomBiome(string previousBiome)
        {
            var random = new Random();
            string biome = "Forest";

            var biomes = new string[]
            {
                "Forest",
                "Jungle",
                "Grasslands",
                "Mountain",
                "Hills",
                "Valley",
                "BadLands",
                "Arctic",
                "Desert",
                "Swamp",
                "Volcanic",
                "Ocean",
                "Riverlands",
                "Tropical"
                //Underground        
            };

            if(previousBiome == "First")
            {
                biome = biomes[random.Next(biomes.Length)];
            }

            switch (previousBiome)
            {               
                case "Forest":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 40 and <= 60:
                                {
                                    biome = "Riverlands";
                                    break;
                                }
                            case > 60 and <= 64:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 64 and <= 68:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 68 and <= 72:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 72 and <= 76:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 76 and <= 80:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 80 and <= 84:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                            case > 84 and <= 88:
                                {
                                    biome = "Tropical";
                                    break;
                                }
                            case > 88 and <= 92:
                                {
                                    biome = "Arctic";
                                    break;
                                }
                            case > 92 and <= 96:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 96 and <= 100:
                                {
                                    biome = "Desert";
                                    break;
                                }
                        } 
                        break;
                    }
                case "Jungle":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 50:
                                {
                                    biome = "Tropical";
                                    break;
                                }
                            case > 50 and <= 60:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 60 and <= 65:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                            case > 65 and <= 67:
                                {
                                    biome = "Arctic";
                                    break;
                                }
                            case > 67 and <= 71:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 71 and <= 75:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 75 and <= 79:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 79 and <= 83:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 83 and <= 87:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 87 and <= 91:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 91 and <= 95:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 95 and <= 100:
                                {
                                    biome = "Hills";
                                    break;
                                }
                        }              
                        break;
                    }
                case "Grasslands":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Riverlands";
                                    break;
                                }
                            case > 40 and <= 50:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 50 and <= 60:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 60 and <= 65:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 65 and <= 70:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 70 and <= 75:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 75 and <= 80:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 80 and <= 85:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 85 and <= 90:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 90 and <= 95:
                                {
                                    biome = "Arctic";
                                    break;
                                }
                            case > 95 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }
                        break;
                    }
                case "Mountain":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 40 and <= 50:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 50 and <= 60:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 60 and <= 63:
                                {
                                    biome = "Riverlands";
                                    break;
                                }
                            case > 63 and <= 66:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 66 and <= 69:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 69 and <= 72:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 72 and <= 75:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 75 and <= 78:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 78 and <= 81:
                                {
                                    biome = "Arctic";
                                    break;
                                }
                            case > 81 and <= 84:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 84 and <= 87:
                                {
                                    biome = "Tropical";
                                    break;
                                }
                            case > 87 and <= 90:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                            case > 90 and <= 100:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                        }
                        break;
                    }
                case "Hills":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Riverlands";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Tropical";
                                    break;
                                }  
                        }
                        break;
                    }
                case "Valley":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 14:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 14 and <= 28:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 28 and <= 42:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 42 and <= 56:
                                {
                                    biome = "Tropical";
                                    break;
                                }
                            case > 56 and <= 60:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 60 and <= 74:
                                {
                                    biome = "Riverlands";
                                    break;
                                }
                            case > 74 and <= 100:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                        }
                        break;
                    }
                case "BadLands":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }                            
                        }
                        break;
                    }
                case "Arctic":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 11:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 11 and <= 22:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 22 and <= 33:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 33 and <= 44:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 44 and <= 55:
                                {
                                    biome = "Hills";
                                    break;
                                }

                            case > 55 and <= 66:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 66 and <= 77:
                                {
                                    biome = "Arcitc";
                                    break;
                                }

                            case > 77 and <= 88:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 88 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }

                        break;
                    }
                case "Desert":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }

                        break;
                    }
                case "Swamp":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }

                        break;
                    }
                case "Ocean":
                    {

                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }
     
                        break;
                    }
                case "Riverlands":
                    {

                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }

                        break;
                    }
                case "Tropical":
                    {
                        switch (GetNewBiomeRNG())
                        {
                            case > 0 and <= 20:
                                {
                                    biome = "Forest";
                                    break;
                                }
                            case > 20 and <= 40:
                                {
                                    biome = "Jungle";
                                    break;
                                }
                            case > 40 and <= 46:
                                {
                                    biome = "Grasslands";
                                    break;
                                }
                            case > 46 and <= 52:
                                {
                                    biome = "Mountain";
                                    break;
                                }
                            case > 52 and <= 58:
                                {
                                    biome = "Hills";
                                    break;
                                }
                            case > 58 and <= 64:
                                {
                                    biome = "Valley";
                                    break;
                                }
                            case > 64 and <= 70:
                                {
                                    biome = "Badlands";
                                    break;
                                }
                            case > 70 and <= 76:
                                {
                                    biome = "Arcitc";
                                    break;
                                }
                            case > 76 and <= 82:
                                {
                                    biome = "Desert";
                                    break;
                                }
                            case > 82 and <= 88:
                                {
                                    biome = "Swamp";
                                    break;
                                }
                            case > 88 and <= 94:
                                {
                                    biome = "Volcanic";
                                    break;
                                }
                            case > 94 and <= 100:
                                {
                                    biome = "Ocean";
                                    break;
                                }
                        }
                        break;
                    }
            }

            return biome;
        }


        public static string GetRandomLocationName()
        {
            var random = new Random();

            var len = random.Next(2, 10);

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[random.Next(consonants.Length)].ToUpper();
            Name += vowels[random.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[random.Next(consonants.Length)];
                b++;
                Name += vowels[random.Next(vowels.Length)];
                b++;
            }
            return Name;
        }

        public static bool GetIsSurfaceLevel(Location location)
        {
            if (location.Biome == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}