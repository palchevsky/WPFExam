using System;

namespace ERP.Model
{
    public class Position : IEquatable<Position>
    {
        public string Positions { get; }

        public Position(string name)
        {
            Positions = name;
        }

        public override string ToString()
        {
            return $"{Positions}";
        }

        public static bool operator ==(Position obj1, Position obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Positions == obj2.Positions;
        }

        public static bool operator !=(Position obj1, Position obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            return ReferenceEquals(this, other) || Positions.Equals(other.Positions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            int hashCode = Positions.GetHashCode();
            return hashCode;
        }


    }
}
