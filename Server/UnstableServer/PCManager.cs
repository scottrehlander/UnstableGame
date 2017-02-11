using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unstable
{    
    /*
     * 
     * 
     * 
     * 
     */
    class PCManager
    {
    }

    enum Race
    {
        human,
        mech,
        dopple,
        orc,
        spider,
        fish
    }

    abstract class organism
    {
        string name;
        int heightInches;
        int weightLBS;
        Race race;
    }
}
