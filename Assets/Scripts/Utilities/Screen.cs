using Codice.Client.Common;
using UnityEditor;
using UnityEngine;


namespace Utilities
{

    public static class Screen
    {

        #region Screen properties in pixels

        public static int WidthInPixels
        {
            get => UnityEngine.Screen.width;
        }

        public static float HalfWidthInPixels
        {
            get => UnityEngine.Screen.width / 2;
        }

        public static int HeightInPixels
        {
            get => UnityEngine.Screen.height;
        }

        public static int HalfHeightInPixels
        {
            get => UnityEngine.Screen.height / 2;
        }

        #endregion

        #region Screen properties in units

        /// <summary>
        /// Conversion based on window width.
        /// </summary>
        public static float WidthInUnits
        {
            get => Camera.main.orthographicSize * 2.0f * WidthInPixels / UnityEngine.Screen.width;
        }

        /// <summary>
        /// Conversion based on window width.
        /// </summary>
        public static float HalfWidthInUnits
        {
            get => WidthInUnits * 0.5f;
        }

        /// <summary>
        /// Conversion based on window height.
        /// </summary>
        public static float HeightInUnits
        {
            get => Camera.main.orthographicSize * 2.0f * HeightInPixels / UnityEngine.Screen.height;
        }

        /// <summary>
        /// Conversion based on window height.
        /// </summary>
        public static float HalfHeightInUnits
        {
            get => HeightInUnits * 0.5f;
        }

        #endregion

        #region Screen position

        public static float PositionX
        {
            get => UnityEngine.Screen.safeArea.x;
        }

        public static float PositionY
        {
            get => UnityEngine.Screen.safeArea.y;
        }

        public static Vector2 Position
        {
            get => UnityEngine.Screen.safeArea.position;
        }

        #endregion


        #region Debug

        public static void PrintScreenWidthInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen width in pixels is: {WidthInPixels}");

        }

        public static void PrintHalfScreenWidthInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen width in pixels is: {HalfWidthInPixels}");

        }

        public static void PrintScreenHeightInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen height in pixels is: {HeightInPixels}");

        }

        public static void PrintHalfScreenHeightInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen height in pixels is: {HalfHeightInPixels}");

        }

        public static void PrintScreenWidthInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen width in units is: {WidthInUnits}");

        }

        public static void PrintHalfScreenWidthInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen width in units is: {HalfWidthInUnits}");

        }

        public static void PrintScreenHeightInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen height in units is: {HeightInUnits}");

        }

        public static void PrintHalfScreenHeightInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen height in units is: {HalfHeightInUnits}");

        }

        public static void PrintScreenPositionX()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position 'X' is: {PositionX}");

        }

        public static void PrintScreenPositionY()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position 'Y' is: {PositionY}");

        }

        public static void PrintScreenPosition()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position is: {Position}");

        }

        public static void PrintAllScreenProperties()
        {

            Debug.Log("-------------------------------------------------------------------------------------");
            Debug.Log($"== UTILITIES.SCREEN == Screen width in pixels is: {WidthInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen width in pixels is: {HalfWidthInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Screen height in pixels is: {HeightInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen height in pixels is: {HalfHeightInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Screen width in units is: {WidthInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen width in units is: {HalfWidthInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Screen height in units is: {HeightInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen height in units is: {HalfHeightInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position 'X' is: {PositionX}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position 'Y' is: {PositionY}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position is: {Position}");
            Debug.Log("-------------------------------------------------------------------------------------");

        }

        #endregion

    }

}