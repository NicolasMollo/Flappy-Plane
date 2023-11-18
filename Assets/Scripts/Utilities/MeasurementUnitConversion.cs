using UnityEngine;


namespace Utilities
{

    public static class MeasurementUnitConversion
    {

        #region Conversion methods

        /// <summary>
        /// Method for X-axis conversion.
        /// This specific method converts quantities only along the X axis into units, based on the width of the camera window
        /// </summary>
        /// <param name="_pixelSizeX"></param>
        /// <returns></returns>
        public static float ConvertPixelsToUnitsOnXAxis(float _pixelSizeX)
        {
 
            Vector3 screenBottomLeft = new Vector3(0, 0, 0);
            Vector3 worldBottomLeft = Camera.main.ScreenToWorldPoint(screenBottomLeft);
            Vector3 screenTopRight = new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, 0);
            Vector3 worldTopRight = Camera.main.ScreenToWorldPoint(screenTopRight);

            float windowWidthInUnits = Mathf.Abs(worldTopRight.x - worldBottomLeft.x);
            float sizeInUnits = _pixelSizeX / UnityEngine.Screen.width * windowWidthInUnits;

            return sizeInUnits;

        }

        /// <summary>
        /// Method for Y-axis conversion.
        /// This specific method converts quantities only along the Y axis into units, based on the height of the camera window
        /// </summary>
        /// <param name="_pixelSizeY"></param>
        /// <returns></returns>
        public static float ConvertPixelsToUnitsOnYAxis(float _pixelSizeY)
        {

            Vector3 screenBottomLeft = new Vector3(0, 0, 0);
            Vector3 worldBottomLeft = Camera.main.ScreenToWorldPoint(screenBottomLeft);
            Vector3 screenTopRight = new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, 0);
            Vector3 worldTopRight = Camera.main.ScreenToWorldPoint(screenTopRight);

            float windowHeightInUnits = Mathf.Abs(worldTopRight.y - worldBottomLeft.y);
            float sizeInUnitsY = _pixelSizeY / UnityEngine.Screen.height * windowHeightInUnits;

            return sizeInUnitsY;

        }


        /// <summary>
        /// Method for conversion on both axes (X and Y).
        /// This method can be used to convert quantities on both the X and Y axes to units, based on the width and height of the camera window
        /// </summary>
        /// <param name="pixelSize"></param>
        /// <returns></returns>
        public static Vector2 ConvertPixelsToUnits(Vector2 pixelSize)
        {

            Vector3 screenBottomLeft = new Vector3(0, 0, 0);
            Vector3 worldBottomLeft = Camera.main.ScreenToWorldPoint(screenBottomLeft);
            Vector3 screenTopRight = new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, 0);
            Vector3 worldTopRight = Camera.main.ScreenToWorldPoint(screenTopRight);

            float windowWidthInUnits = Mathf.Abs(worldTopRight.x - worldBottomLeft.x);
            float windowHeightInUnits = Mathf.Abs(worldTopRight.y - worldBottomLeft.y);
            float sizeInUnitsX = pixelSize.x / UnityEngine.Screen.width * windowWidthInUnits;
            float sizeInUnitsY = pixelSize.y / UnityEngine.Screen.height * windowHeightInUnits;

            return new Vector2(sizeInUnitsX, sizeInUnitsY);

        }

        #endregion

    }

}