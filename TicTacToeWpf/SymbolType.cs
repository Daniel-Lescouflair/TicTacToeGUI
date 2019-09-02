using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWpf
{
    /// <summary>
    /// The type of value in a cell in the game is current at.
    /// </summary>
    public enum SymbolType
    {
        /// <summary>
        /// The cell has not been clicked yet.
        /// </summary>
        Empty,
        /// <summary>
        /// The cell is a O.
        /// </summary>
        Circle,
        /// <summary>
        /// The Cell has an X/
        /// </summary>
        Cross
    }
}
