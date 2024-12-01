using UnityEngine;

public static class OrientationFactory
{
    // Turret Direction Variables
    private static Quaternion Up = Quaternion.Euler(0, 90, 0);
    private static Quaternion Down = Quaternion.Euler(0, -90, 0);
    private static Quaternion Left = Quaternion.Euler(0, 0, 0);
    private static Quaternion Right = Quaternion.Euler(0, 180, 0);

    public static Quaternion GetRotation(Vector3 position)
    {
        float x = position.x;
        float z = position.z;

        // Grouped conditions based on x
        if (x == 7)
            return Left;
        if (x == -5 && z <= -6)
            return Right;
        if (x == 5 && z <= -6)
            return Left;

        // Grouped conditions based on z
        if (z == 2 || (z == 0 && x <= -4))
            return Down;
        if (z == -1)
            return Left;
        if (z == -2)
        {
            if (x == -3 || x == -2)
                return Down;
            if (x == 1 || x == 2)
                return Up;
            if (x == 3)
                return Right;
        }
        if (z == -3 || z == -4)
        {
            if (x == -8 || x == -7)
                return Up;
            if (x == -1)
                return Left;
            if (x == 1)
                return Right;
        }
        if (z == -5)
        {
            if (x == -7)
                return Right;
            if (x == -1 || x == 1)
                return Down;
        }
        if (z == -6)
        {
            if (x == -6 || x == 6)
                return Up;
        }
        if (z == -9)
            return Up;

        // Default rotation
        return Up;
    }
}
