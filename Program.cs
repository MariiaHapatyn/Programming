using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_tests {
    public class Program3 {
        public class Point {
            private int x;
            private int y;
            public int X {
                get { return x; }
                set { x = value; }
            }
            public int Y {
                get { return y; }
                set { y = value; }
            }
            
            public Point () {
                x = 0;
                y = 0;
            }
            public Point ( int x1, int y1 ) {
                x = x1;
                y = y1;
            }
            public bool IsRightAngle(Point p1, Point p2) {
                int a = p1.x - x;
                int b = p1.y - y;
                int c = p2.x - x;
                int d = p2.y - y;
                int sdv = a * b + c * d;
                return (sdv == 0);
            }
        }
        public class Rectangle {
            private Point a;
            private Point b;
            private Point c;
            private Point d;
            public Point A {
                get { return a; }
                set { a = value; }
            }
            public Point B {
                get { return b; }
                set { b = value; }
            }
            public Point C {
                get { return c; }
                set { c = value; }
            }
            public Point D {
                get { return d; }
                set { d = value; }
            }

            private void MakeClockwiseOrder() {
                Point[ ] a1 = { a, b, c, d };
                if (IsRightangle(a1)) {
                    a = a1[0];
                    b = a1[1];
                    c = a1[2];
                    d = a1[3];
                }
                Point[ ] a2 = { b, a, c, d };
                if( IsRightangle( a2 ) ) {
                    a = a2[0];
                    b = a2[1];
                    c = a2[2];
                    d = a2[3];
                }
                Point[ ] a3 = { a, d, b, c };
                if( IsRightangle( a3 ) ) {
                    a = a3[0];
                    b = a3[1];
                    c = a3[2];
                    d = a3[3];
                }
                Point[ ] a4 = { c, b, a, d };
                if( IsRightangle( a4 ) ) {
                    a = a4[0];
                    b = a4[1];
                    c = a4[2];
                    d = a4[3];
                }
                Point[ ] a5 = { a, d, c, b };
                if( IsRightangle( a5 ) ) {
                    a = a5[0];
                    b = a5[1];
                    c = a5[2];
                    d = a5[3];
                }
                Point[ ] a6 = { b, a, d, c };
                if( IsRightangle( a6 ) ) {
                    a = a6[0];
                    b = a6[1];
                    c = a6[2];
                    d = a6[3];
                }
            }

            public Rectangle ( Point _a, Point _b, Point _c, Point _d ) {
                a = _a;
                b = _b;
                c = _c;
                d = _d;
            }

            public double Distance ( Point a1, Point a2 ) {
                double dist = Math.Sqrt( ( a2.X - a1.X ) * ( a2.X - a1.X ) + ( a2.Y - a1.Y ) * ( a2.Y - a1.Y ) );
                return dist;
            }

            public double Perimeter () {
                MakeClockwiseOrder();
                if (Distance(A,B) == 0 || Distance(B,C) == 0 || Distance( C, D ) == 0 || Distance( D, A ) == 0 || Distance( A, C ) == 0 || Distance( B, D ) == 0  ) 
                {
                    throw new ArgumentException();
                }
                return Distance( A, B ) + Distance( B, C ) + Distance( C, D ) + Distance( D, A );
            }

            private bool IsRightangle(Point[ ] points ) {
                bool result = true;
                for (int i = 0; i<4; ++i) {
                    int b = ( i + 1 ) % 4;
                    int c = ( i + 2 ) % 4;
                    result &= points[b].IsRightAngle( points[i], points[c] );
                }
                return result;
            }

            private bool IsTheSameDist(Point[ ] bb ) {
                double dist = Distance( bb[0], bb[1] );
                for (int i = 1; i<4; ++i) {
                    int next = ( i + 1 ) % 4;
                    if( !Distance( bb[i], bb[next] ).Equals( dist ) )
                        return false;
                }
                return true;
            }

            public bool IsARectangle () { 
                Point[ ] a1 = { a, b, c, d };
                MakeClockwiseOrder();
                return ( IsRightangle( a1 )  && !IsTheSameDist( a1 ) );
            }

            public bool IsASquare () {
                Point[ ] a1 = { a, b, c, d };
                MakeClockwiseOrder();
                return ( IsRightangle( a1 ) && IsTheSameDist( a1 ) );
            }

            public void input() {
                int[ ] pointsN = Console.ReadLine().Split().Select( int.Parse ).ToArray();
                a.X = pointsN[0];
                a.Y = pointsN[1];
                b.X = pointsN[2];
                b.Y = pointsN[3];
                c.X = pointsN[4];
                c.Y = pointsN[5];
                d.X = pointsN[6];
                d.Y = pointsN[7];
            }

            public static bool operator<( Rectangle lhs, Rectangle rhs ) {
                return lhs.Perimeter() < rhs.Perimeter();
            }

            public static bool operator>( Rectangle lhs, Rectangle rhs ) {
                return lhs.Perimeter() > rhs.Perimeter();
            }

            public void output () {
                Console.WriteLine( $"RECTANGLE:\nA = ({a.X};{a.Y})\nB = ({b.X};{b.Y})\nC = ({c.X};{c.Y})\nD = ({d.X};{d.Y})\nPERIMETER = {Perimeter()}\n");
            }

        }
        public static void Main ( string[ ] args ) {
            

            Rectangle r1 = new Rectangle( new Point( 0, 0 ), new Point( 0, 1 ), new Point( 1, 1 ), new Point( 1, 0 ) );
            Rectangle r2 = new Rectangle( new Point( 1, 2 ), new Point( 7, 2 ), new Point( 7, 5 ), new Point( 1, 5 ) );
            Rectangle r3 = new Rectangle( new Point( 7, 5 ), new Point( 1, 2 ), new Point( 1, 5 ), new Point( 7, 2 ) );
            Rectangle r4 = new Rectangle( new Point( 0, 0 ), new Point( 0, 2 ), new Point( 2, 0 ), new Point( 2, 2 ) );
            Rectangle r5 = new Rectangle( new Point( 2, 0 ), new Point( 5, 0 ), new Point( 2, 1 ), new Point( 5, 1 ) );
            Rectangle r6 = new Rectangle( new Point( 1, 1 ), new Point( 3, 2 ), new Point( 2, 4 ), new Point( 0, 3 ) );
            Rectangle r7 = new Rectangle( new Point( 1, 3 ), new Point( 3, 3 ), new Point( 3, 1 ), new Point( 1, 1 ) );
            Rectangle r8 = new Rectangle( new Point( 0, 0 ), new Point( 0, 1 ), new Point( 1, 1 ), new Point( 1, 0 ) );
            Rectangle r9 = new Rectangle( new Point( 2, 0 ), new Point( 0, 0 ), new Point( 0, 1 ), new Point( 2, 1 ) );
            Rectangle r10 = new Rectangle( new Point( 3, 4 ), new Point( 4, 4 ), new Point( 4, 0 ), new Point( 3, 0 ) );
            Rectangle[ ] arr = { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            
            Console.WriteLine( "Printing all in sorted order:\n" );

            for( int i = 0; i<arr.Length; ++i ) {
                for (int j = i+1; j<arr.Length;  ++j) {
                    if (arr[i] < arr[j]) {
                        Rectangle toSwap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = toSwap;
                    }
                }
            }
            for (int i = 0; i<arr.Length; ++i) {
                arr[i].output();
            }
            Console.WriteLine("\nPrinting only squares:\n");
            for ( int i = 0; i<arr.Length; ++i) {
                if (arr[i].IsASquare()) {
                    arr[i].output();
                }
            }
            Console.WriteLine( "\nPrinting only rectangles:\n" );
            for( int i = 0; i < arr.Length; ++i ) {
                if( arr[i].IsARectangle() ) {
                    arr[i].output();
                }
            }
        }
    }
}
