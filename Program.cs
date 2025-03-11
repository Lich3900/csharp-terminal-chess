using System;
using System.Text;
class Chess {
    int[,] chessBoard = new int [9,9];
    // 0 - nothing
    // 1 - white pawn(13 if moved), 2 - white knight
    // 3 - white bishop, 4 - white rook (14 if moved)
    // 5 - white queen, 6 - white king (15 if moved)
    // 7 - black pawn (16 if moved), 8 - black knight
    // 9 - black bishop, 10 - black rook (17 if moved)
    // 11 - black queen, 12 - black king  (18 if moved)
    public void gameStart(){
        Console.WriteLine("Welcome to the game! Bottom ones are white btw");
    }
    public void restartBoard(){
        chessBoard = new int[,] {
                    {0,0,0,0,0,0,0,0,0},
                    {0,10,8,9,11,12,9,8,10},
                    {0,7,7,7,7,7,7,7,7},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,0,0,0,0,0,0,0,0},
                    {0,1,1,1,1,1,1,1,1},
                    {0,4,2,3,5,6,3,2,4}};
    }
    public void drawBoard(){
        for(int i = 1; i <= 8; i++){
            //Console.Write("|");
            for(int j = 0; j <= 8; j++){
                if(j == 0){
                    Console.Write(9-i+"|");
                }
                else{
                switch(chessBoard[i,j]){
                    case int n when (n == 1 || n == 13):
                        Console.Write("♙|");
                        break;
                    case 2:
                        Console.Write("♘|");
                        break; 
                    case 3:
                        Console.Write("♗|");
                        break;
                    case int n when (n == 4 || n == 14):
                        Console.Write("♖|");
                        break;
                    case 5:
                        Console.Write("♕|");
                        break;
                    case int n when (n == 6 || n == 15):
                        Console.Write("♔|");
                        break; 
                    case int n when (n == 7 || n == 16):
                        Console.Write("♟|");
                        break;
                    case 8:
                        Console.Write("♞|");
                        break;
                    case 9:
                        Console.Write("♝|");
                        break;
                    case int n when (n == 10 || n == 17):
                        Console.Write("♜|");
                        break; 
                    case 11:
                        Console.Write("♛|");
                        break;
                    case int n when (n == 12 || n == 18):
                        Console.Write("♚|");
                        break;
                    case 0:
                        Console.Write(" |");
                        break;
                }
                }
            }
            Console.Write("\n------------------\n");
        }
        Console.Write(" |1|2|3|4|5|6|7|8|\n");
    }
    public int MakeMove(int firstRow, int firstCol,int lastRow, int lastCol){ // Makes moves intself, shuffles figures around
        if(firstCol >= 1 && firstCol <= 8 && firstRow >= 1 && firstRow <= 8 && lastCol >= 1 && lastCol <= 8 && lastRow >= 1 && lastRow <= 8) //small check for boundaries
            if(isValid(9-firstRow,firstCol,9-lastRow,lastCol,chessBoard[9-firstRow,firstCol]) == 1){
                chessBoard[9-firstRow,firstCol] = CheckForFirstMove(chessBoard[9-firstRow,firstCol]);
                chessBoard[9-lastRow,lastCol] = chessBoard[9-firstRow,firstCol];
                chessBoard[9-firstRow,firstCol] = 0;
                Console.WriteLine("Move made is " + firstRow + " " + firstCol + " to " + lastRow + " " + lastCol + " in type " + chessBoard[9-firstRow,firstCol]);
                //testing tool
                return 1;
            }
            else{
                Console.WriteLine("move is illegal, try again");
                return 0;
            }
        else{
            Console.WriteLine("Move is out of range, try again");
            return 0;
        }
        
    }
    public int isValid(int firstRow, int firstCol,int lastRow, int lastCol, int type){
        if(type == 0) return 0;
        switch(type){
        case int n when (n == 1 || n == 13): return isValidPawn(firstRow,firstCol,lastRow,lastCol);
            break;
        case 2: return isValidKnight(firstRow,firstCol,lastRow,lastCol);
            break; 
        case 3:
            Console.Write("♗|");
            break;
        case 4:
            Console.Write("♖|");
            break;
        case 5:
            Console.Write("♕|");
            break;
        case 6:
            Console.Write("♔|");
            break; 
        case int n when (n == 7 || n == 16): return isValidPawn(firstRow,firstCol,lastRow,lastCol);
            break;
        case 8: return isValidKnight(firstRow,firstCol,lastRow,lastCol);
            break;
        case 9:
            Console.Write("♝|");
            break;
        case 10:
            Console.Write("♜|");
            break; 
        case 11:
            Console.Write("♛|");
            break;
        case 12:
            Console.Write("♚|");
            break;
        case 0:
            Console.Write(" |");
            break;
        }
    return 1;
    }
    public int isValidPawn(int startRow, int startCol, int endRow, int endCol){
        if(chessBoard[startRow,startCol] == 1 || chessBoard[startRow,startCol] == 13){
            if(chessBoard[startRow,startCol] == 13) //white which moved
                if((startCol == endCol && startRow - endRow == 1 && chessBoard[endRow,endCol] == 0) || (((startCol == endCol+1 || startCol == endCol-1) && startRow - endRow == 1 && chessBoard[endRow,endCol] != 0)))
                    return 1;
                else 
                    return 0;
            else
                if((startCol == endCol && (startRow - endRow == 1 || startRow - endRow == 2) && chessBoard[endRow,endCol] == 0) || ((startCol == endCol+1 || startCol == endCol-1) && startRow - endRow == 1 && chessBoard[endRow,endCol] != 0))
                    return 1;
                else //white that hasnt moved
                    return 0;
        } //white
        else {
            if(chessBoard[startRow,startCol] == 16) //black which moved
                if((startCol == endCol && startRow - endRow == -1 && chessBoard[endRow,endCol] == 0) || (((startCol == endCol+1 || startCol == endCol-1) && startRow - endRow == -1 && chessBoard[endRow,endCol] != 0)))
                    return 1;
                else 
                    return 0;
            else
                if((startCol == endCol && (startRow - endRow == -1 || startRow - endRow == -2) && chessBoard[endRow,endCol] == 0) || ((startCol == endCol+1 || startCol == endCol-1) && startRow - endRow == -1 && chessBoard[endRow,endCol] != 0))
                    return 1;
                else //black that hasnt moved
                    return 0;
        }//black
    }
    public int isValidKnight(int startRow, int startCol, int endRow, int endCol){
        //check for is the move is right
        if((Math.Abs(endRow - startRow) == 2 && Math.Abs(endCol - startCol) == 1) ||(Math.Abs(endRow - startRow) == 1 && Math.Abs(endCol - startCol) == 2)){
            if(chessBoard[startRow, startCol] == 2)
                return (new int[] {7,8,9,10,11,12,16,17,18,0}.Contains(chessBoard[endRow, endCol])) ? 1 : 0;
            else 
                return (new int[] {1,2,3,4,5,6,13,14,15,0}.Contains(chessBoard[endRow, endCol])) ? 1 : 0;
        }
        else{
            Console.WriteLine("Help me pls");
            return 0;
        }
    }
    public int isValidBishop(int startRow, int startCol, int endRow, int endCol){
        return 1;
    }
    public int isValidRook(int startRow, int startCol, int endRow, int endCol){
        return 1;
    }
    public int isValidQueen(int startRow, int startCol, int endRow, int endCol){
        return 1;
    }
    public int isValidKing(int startRow, int startCol, int endRow, int endCol){
        return 1;
    }
    public int CheckForFirstMove(int i){
        switch(i){
            case 1:
                return 13;
                break;
            case 4:
                return 14;
                break;
            case 6:
                return 15;
                break;
            case 7:
                return 16;
                break;
            case 10:
                return 17;
                break;
            case 12:
                return 18;
                break;
            default:
                return i;
            break;
        }
    }
}
class Programm {
    static void Main(){
        Chess pisa = new Chess();
        pisa.restartBoard();
        while(true){
            pisa.drawBoard();
            Console.WriteLine("Please provide a move in this format (strRow) (strCol) (endRiw) (endCol)");
            string str = Console.ReadLine();
            string[] nums = str.Split(' ');
            pisa.MakeMove(int.Parse(nums[0]),int.Parse(nums[1]),int.Parse(nums[2]),int.Parse(nums[3]));
        }
    }
} 