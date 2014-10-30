using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    interface Controllable
    {
        void OnLeftDown();
        void OnRightDown();
        void OnSpaceDown();
        void OnLeftUp();
    }
}
