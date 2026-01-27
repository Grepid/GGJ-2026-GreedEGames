using UnityEngine;
using System.Collections.Generic;

public enum OrderDifficulty
{
    Easy,
    Medium,
    Hard
}
public static class CustomerOrderGenerator
{
    //Probably un-ndeeded
    public static readonly List<string> BaseToMatFillers = new()
    {
        "And then",
        
    };

    public static readonly Dictionary<OrderDifficulty, Dictionary<Mask.Base, List<string>>> MaskBaseRequests = new()
    {
        //All Easy Mask Base lines
        {OrderDifficulty.Easy,new()
            {
                {Mask.Base.Square,new()
                    {
                        "I want a Square Base",
                        "Can I have a Square Base"
                    } 
                },
                {Mask.Base.Small,new()
                    {
                        "I want a Small Base",
                        "Can I have a Small Base"
                    }
                },
                {Mask.Base.Simple,new()
                    {
                        "I want a Simple Base",
                        "Can I have a Simple Base"
                    }
                }
            } 
        },

        //All Medium Mask Base lines
        {OrderDifficulty.Medium,new()
            {
                {Mask.Base.Square,new()
                    {
                        "I want whatever isn't rounded",
                        "I'm a fan of sharper corners"
                    }
                },
                {Mask.Base.Small,new()
                    {
                        "Don't make the base too big",
                        "I'm not a fan of the larger masks"
                    }
                },
                {Mask.Base.Simple,new()
                    {
                        "I don't want a complex base for my mask",
                        "These modern masks are too complex for me"
                    }
                }
            }
        },

        //All Hard Mask Base lines
        {OrderDifficulty.Hard,new()
            {
                {Mask.Base.Square,new()
                    {
                        "I want a base that is banned, but fashionable",
                    }
                },
                {Mask.Base.Small,new()
                    {
                        "I want a base that is banned, but fashionable",
                    }
                },
                {Mask.Base.Simple,new()
                    {
                        "I want a base that is banned, but fashionable",
                    }
                }
            }
        }
    };

    public static readonly Dictionary<OrderDifficulty, Dictionary<Mask.Material, List<string>>> MaskMaterialRequests = new()
    {
        //All Easy Mask Material lines
        {OrderDifficulty.Easy,new()
            {
                {Mask.Material.Iron,new()
                    {
                        "I want it made of Iron",
                        "Can I have it be made of Iron"
                    }
                },
                {Mask.Material.Silver,new()
                    {
                        "I want it made of Silver",
                        "Can I have it be made of Silver"
                    }
                },
                {Mask.Material.Gold,new()
                    {
                        "I want it made of Gold",
                        "Can I have it made of Gold"
                    }
                }
            }
        },

        //All Medium Mask Material lines
        {OrderDifficulty.Medium,new()
            {
                {Mask.Material.Iron,new()
                    {
                        "I want a durable mask",
                        "Can I have a durable material"
                    }
                },
                {Mask.Material.Silver,new()
                    {
                        "I want a fancy bright material",
                        "Can I have a fancy shiny material"
                    }
                },
                {Mask.Material.Gold,new()
                    {
                        "I want a rich, elegent material",
                        "Can I have the richest material you have"
                    }
                }
            }
        },

        //All Hard Mask Material lines
        {OrderDifficulty.Hard,new()
            {
                {Mask.Material.Iron,new()
                    {
                        "I want a material that is banned, but fashionable",
                    }
                },
                {Mask.Material.Silver,new()
                    {
                        "I want a material that is banned, but fashionable",
                    }
                },
                {Mask.Material.Gold,new()
                    {
                        "I want a material that is banned, but fashionable",
                    }
                }
            }
        }
    };

    public static readonly Dictionary<OrderDifficulty, Dictionary<Mask.Feather, List<string>>> MaskFeatherRequests = new()
    {
        //All Easy Mask Feather lines
        {OrderDifficulty.Easy,new()
            {
                {Mask.Feather.Red,new()
                    {
                        "I want a Red Feather",
                        "Can I have a Red Feather"
                    }
                },
                {Mask.Feather.White,new()
                    {
                        "I want a White Feather",
                        "Can I have a White Feather"
                    }
                },
                {Mask.Feather.Black,new()
                    {
                        "I want a Black Feather",
                        "Can I have a Black Feather"
                    }
                },
                {Mask.Feather.Purple,new()
                    {
                        "I want a Purple Feather",
                        "Can I have a Purple Feather"
                    }
                },
                {Mask.Feather.Yellow,new()
                    {
                        "I want a Yellow Feather",
                        "Can I have a Yellow Feather"
                    }
                }
            }
        },

        //All Medium Mask Feather lines
        {OrderDifficulty.Medium,new()
            {
                {Mask.Feather.Red,new()
                    {
                        "I am quite fond of Red Birds",
                        "Can I have a part of a Red Bird"
                    }
                },
                {Mask.Feather.White,new()
                    {
                        "I am quite fond of Whtie Birds",
                        "Can I have a part of a White Bird"
                    }
                },
                {Mask.Feather.Black,new()
                    {
                        "I am quite fond of Black Birds",
                        "Can I have a part of a Black Bird"
                    }
                },
                {Mask.Feather.Purple,new()
                    {
                        "I am quite fond of Purple Birds",
                        "Can I have a part of a Purple Bird"
                    }
                },
                {Mask.Feather.Yellow,new()
                    {
                        "I am quite fond of Yellow Birds",
                        "Can I have a part of a Yellow Bird"
                    }
                }
            }
        },

        //All Hard Mask Feather lines
        {OrderDifficulty.Hard,new()
            {
                {Mask.Feather.Red,new()
                    {
                        "I want a Polk Finch Feather",
                        "Can I have a Polk Finch Feather"
                    }
                },
                {Mask.Feather.White,new()
                    {
                        "I want a Wine Bird Feather",
                        "Can I have a Wine Bird Feather"
                    }
                },
                {Mask.Feather.Black,new()
                    {
                        "I want a Trian Stork Feather",
                        "Can I have a Trian Stork Feather"
                    }
                },
                {Mask.Feather.Purple,new()
                    {
                        "I want a Seal Swan Feather",
                        "Can I have a Seal Swan Feather"
                    }
                },
                {Mask.Feather.Yellow,new()
                    {
                        "I want a Joan Cuckoo Feather",
                        "Can I have a Joan Cuckoo Feather"
                    }
                }
            }
        }
    };
}
