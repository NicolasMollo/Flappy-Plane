using Codice.Client.Common;
using UnityEditor;
using UnityEngine;


namespace Utilities
{

    public static class Screen
    {

        #region Screen properties in pixels

        public static int ScreenWidthInPixels
        {
            get => UnityEngine.Screen.width;
        }

        public static float HalfScreenWidthInPixels
        {
            get => UnityEngine.Screen.width / 2;
        }

        public static int ScreenHeightInPixels
        {
            get => UnityEngine.Screen.height;
        }

        public static int HalfScreenHeightInPixels
        {
            get => UnityEngine.Screen.height / 2;
        }

        #endregion

        #region Screen properties in units

        public static float ScreenWidthInUnits
        {
            get => Camera.main.orthographicSize * 2.0f * ScreenWidthInPixels / UnityEngine.Screen.width;
        }

        public static float HalfScreenWidthInUnits
        {
            get => ScreenWidthInUnits * 0.5f;
        }

        public static float ScreenHeightInUnits
        {
            get => Camera.main.orthographicSize * 2.0f * ScreenHeightInPixels / UnityEngine.Screen.height;
        }

        public static float HalfScreenHeightInUnits
        {
            get => ScreenHeightInUnits * 0.5f;
        }

        #endregion

        #region Screen position

        public static float ScreenPositionX
        {
            get => UnityEngine.Screen.safeArea.x;
        }

        public static float ScreenPositionY
        {
            get => UnityEngine.Screen.safeArea.y;
        }

        public static Vector2 ScreenPosition
        {
            get => UnityEngine.Screen.safeArea.position;
        }

        #endregion

        #region Debug

        public static void PrintScreenWidthInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen width in pixels is: {ScreenWidthInPixels}");

        }

        public static void PrintHalfScreenWidthInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen width in pixels is: {HalfScreenWidthInPixels}");

        }

        public static void PrintScreenHeightInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen height in pixels is: {ScreenHeightInPixels}");

        }

        public static void PrintHalfScreenHeightInPixels()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen height in pixels is: {HalfScreenHeightInPixels}");

        }

        public static void PrintScreenWidthInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen width in units is: {ScreenWidthInUnits}");

        }

        public static void PrintHalfScreenWidthInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen width in units is: {HalfScreenWidthInUnits}");

        }

        public static void PrintScreenHeightInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen height in units is: {ScreenHeightInUnits}");

        }

        public static void PrintHalfScreenHeightInUnits()
        {

            Debug.Log($"== UTILITIES.SCREEN == Half screen height in units is: {HalfScreenHeightInUnits}");

        }

        public static void PrintScreenPositionX()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position 'X' is: {ScreenPositionX}");

        }

        public static void PrintScreenPositionY()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position 'Y' is: {ScreenPositionY}");

        }

        public static void PrintScreenPosition()
        {

            Debug.Log($"== UTILITIES.SCREEN == Screen position is: {ScreenPosition}");

        }

        public static void PrintAllScreenProperties()
        {

            Debug.Log("-------------------------------------------------------------------------------------");
            Debug.Log($"== UTILITIES.SCREEN == Screen width in pixels is: {ScreenWidthInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen width in pixels is: {HalfScreenWidthInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Screen height in pixels is: {ScreenHeightInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen height in pixels is: {HalfScreenHeightInPixels}");
            Debug.Log($"== UTILITIES.SCREEN == Screen width in units is: {ScreenWidthInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen width in units is: {HalfScreenWidthInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Screen height in units is: {ScreenHeightInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Half screen height in units is: {HalfScreenHeightInUnits}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position 'X' is: {ScreenPositionX}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position 'Y' is: {ScreenPositionY}");
            Debug.Log($"== UTILITIES.SCREEN == Screen position is: {ScreenPosition}");
            Debug.Log("-------------------------------------------------------------------------------------");

        }

        #endregion

    }

}