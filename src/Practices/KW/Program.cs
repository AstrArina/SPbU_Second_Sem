using System.Numerics;
using System.Runtime.Intrinsics;

namespace SparseVector;

SparseVector vector1 = new SparseVector();
SparseVector vector2 = new SparseVector();

vector1.SetValue(0, 1);
vector1.SetValue(1, 2);
vector1.SetValue(3, 4);

vector2.SetValue(1, 3);
vector2.SetValue(2, 5);

SparseVector sumVector = vector1.Add(vector2);
SparseVector difVector = Vector2.Subtract(Vector2);

double DotProduct(vector2);
bool isVectorZero



