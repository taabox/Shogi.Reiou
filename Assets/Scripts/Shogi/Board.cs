using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shogi.Reiou
{
	public class Board : MonoBehaviour
	{
		[SerializeField] private Transform _bottomLeftSquareTransform;
		private const float SQUARE_SIZE_X = -0.035f;
		private const float SQUARE_SIZE_Z = -0.0385f;

		public Vector3 CalculatePositionFromCoords(Vector2Int coords)
		{
			return _bottomLeftSquareTransform.localPosition + new Vector3(coords.x * SQUARE_SIZE_X, 0f, coords.y * SQUARE_SIZE_Z);
		}
	}
}