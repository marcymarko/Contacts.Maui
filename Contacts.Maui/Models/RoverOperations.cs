
namespace Contacts.Maui.Models
{
    public static class RoverOperations
    {
        public static void Calculate(RoverData roverData)
        {
            var bounds = roverData.Bounds.Trim().Split(' ').Select(int.Parse).ToList();
            var startPos = roverData.CurrentPosition.Trim().Split(' ');
            
            Position position = new Position();

            if (startPos.Length == 3)
            {
                position.X = Convert.ToInt32(startPos[0]);
                position.Y = Convert.ToInt32(startPos[1]);
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startPos[2].ToUpper());
            }

            var instructions = roverData.MoveInstructions.ToUpper();            

            try
            {
                position.StartMoving(bounds, instructions);
                Result = $"Feedback from the rovers to NASA: {position.X} {position.Y} {position.Direction}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string Result;

        public enum Directions
        {
            N = 1,
            S = 2,
            E = 3,
            W = 4
        }

        public interface IPosition
        {
            void StartMoving(List<int> maxPoints, string moves);
        }


        public class Position : IPosition
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Directions Direction { get; set; }

            public Position()
            {
                X = Y = 0;
                Direction = Directions.N;
            }

            private void Rotate90Left()
            {
                switch (Direction)
                {
                    case Directions.N:
                        Direction = Directions.W;
                        break;
                    case Directions.S:
                        Direction = Directions.E;
                        break;
                    case Directions.E:
                        Direction = Directions.N;
                        break;
                    case Directions.W:
                        Direction = Directions.S;
                        break;
                    default:
                        break;
                }
            }

            private void Rotate90Right()
            {
                switch (Direction)
                {
                    case Directions.N:
                        Direction = Directions.E;
                        break;
                    case Directions.S:
                        Direction = Directions.W;
                        break;
                    case Directions.E:
                        Direction = Directions.S;
                        break;
                    case Directions.W:
                        Direction = Directions.N;
                        break;
                    default:
                        break;
                }
            }

            private void MoveInSameDirection()
            {
                switch (Direction)
                {
                    case Directions.N:
                        Y += 1;
                        break;
                    case Directions.S:
                        Y -= 1;
                        break;
                    case Directions.E:
                        X += 1;
                        break;
                    case Directions.W:
                        X -= 1;
                        break;
                    default:
                        break;
                }
            }

            public void StartMoving(List<int> bounds, string moves)
            {
                foreach (var move in moves)
                {
                    switch (move)
                    {
                        case 'M':
                            MoveInSameDirection();
                            break;
                        case 'L':
                            Rotate90Left();
                            break;
                        case 'R':
                            Rotate90Right();
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {move}");
                            break;
                    }

                    if (X < 0 || X > bounds[0] || Y < 0 || Y > bounds[1])
                    {
                        throw new Exception($"Position can not be beyond bounderies (0 , 0) and ({bounds[0]} , {bounds[1]})");
                    }
                }
            }
        }       
    }
}
