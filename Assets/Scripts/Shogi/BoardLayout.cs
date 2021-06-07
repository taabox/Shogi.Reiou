using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shogi.Reiou
{
	[CreateAssetMenu(menuName = "Scriptable Objects/ShogiBoard/Layout")]
	public class BoardLayout : ScriptableObject
	{
		[Serializable]
		private class BoardSquareSetUp
		{
			[SerializeField] Vector2Int _position;
			public Vector2Int Position => _position;

			[SerializeField] private PieceType _pieceType;
			public PieceType PieceType => _pieceType;

			[SerializeField] private Turn _turn;
			public Turn Turn => _turn;
		}

		[SerializeField] private BoardSquareSetUp[] _boardSquares;

		public int GetPiecesCount()
		{
			return _boardSquares.Length;
		}

		public Vector2Int GetSquareCoordsAtIndex(int index)
		{
			if (_boardSquares.Length <= index)
			{
				Debug.LogError("範囲外です");
				return new Vector2Int(-1, -1);
			}
			return new Vector2Int(_boardSquares[index].Position.x - 1, _boardSquares[index].Position.y - 1);
		}

		public string GetSquarePiaceNameAtIndex(int index)
		{
			if (_boardSquares.Length <= index)
			{
				Debug.LogError("範囲外です");
				return "";
			}
			return _boardSquares[index].PieceType.ToString();
		}

		public Turn GetSquareTurnAtIndex(int index)
		{
			if (_boardSquares.Length <= index)
			{
				Debug.LogError("範囲外です");
				return Turn.Sente;
			}
			return _boardSquares[index].Turn;
		}
	}
}