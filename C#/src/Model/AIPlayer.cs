// '' <summary>
// '' The AIPlayer is a type of player. It can readomly deploy ships, it also has the
// '' functionality to generate coordinates and shoot at tiles
// '' </summary>
public abstract class AIPlayer {
    
    // '' <summary>
    // '' Location can store the location of the last hit made by an
    // '' AI Player. The use of which determines the difficulty.
    // '' </summary>
    class Location {
        
        private int _Row;
        
        private int _Column;
        
        // '' <summary>
        // '' The row of the shot
        // '' </summary>
        // '' <value>The row of the shot</value>
        // '' <returns>The row of the shot</returns>
        public int Row {
            get {
                return _Row;
            }
            set {
                _Row = value;
            }
        }
        
        public int Column {
            get {
                return _Column;
            }
            set {
                _Column = value;
            }
        }
        
        public Location(int row, int column) {
            _Column = column;
            _Row = row;
        }
    
    }

    
    Public(BattleShipsGame game) : base(game) {

    }
    
    // '' <summary>
    // '' Generate a valid row, column to shoot at
    // '' </summary>
    // '' <param name="row">output the row for the next shot</param>
    // '' <param name="column">output the column for the next show</param>
    protected override void GenerateCoords(ref int row, ref int column) {
        // '' <summary>
        // '' The last shot had the following result. Child classes can use this
        // '' to prepare for the next shot.
        // '' </summary>
        // '' <param name="result">The result of the shot</param>
        // '' <param name="row">the row shot</param>
        // '' <param name="col">the column shot</param>
    }
    
     void ProcessShot(int row, int col, AttackResult result) {
        // '' <summary>
        // '' The AI takes its attacks until its go is over.
        // '' </summary>
        // '' <returns>The result of the last attack</returns>
    }
    
    final AttackResult Attack() {
        AttackResult result;
        int row = 0;
        int column = 0;
        for (
        ; ((result.Value != ResultOfAttack.Miss) 
                    && ((result.Value != ResultOfAttack.GameOver) 
                    && !SwinGame.WindowCloseRequested)); 
        ) {
            this.Delay();
            this.GenerateCoords(row, column);
            // generate coordinates for shot
            result = _game.Shoot(row, column);
            // take shot
            this.ProcessShot(row, column, result);
        }
        
        return result;
    }
    
    // '' <summary>
    // '' Wait a short period to simulate the think time
    // '' </summary>
    private void Delay() {
        int i;
        for (i = 0; (i <= 150); i++) {
            // Dont delay if window is closed
            if (SwinGame.WindowCloseRequested) {
                return SwinGame.Delay(5);
            }
            
            SwinGame.ProcessEvents();
            SwinGame.RefreshScreen();
        }
        
    }
}