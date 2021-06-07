using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shogi.Reiou
{
	[RequireComponent(typeof(PieceCreator))]
	public class ShogiGameController : MonoBehaviour
	{
		[SerializeField] private BoardLayout _startingBoardLayout;
		[SerializeField] private Board _board;

		private PieceCreator _pieceCreator;
		//private ShogiPlayer _sentePlayer;
		//private ShogiPlayer _gotePlayer;

		private void Awake()
		{
			SetDependencies();
		}

		private void SetDependencies()
		{
			_pieceCreator = GetComponent<PieceCreator>();
		}

		private void Start()
		{
			StartNewGame();
		}

		private void StartNewGame()
		{
			CreatePiecesFromLayout(_startingBoardLayout);
		}

		private void CreatePiecesFromLayout(BoardLayout layout)
		{
			for (int i = 0; i < layout.GetPiecesCount(); i++)
			{
				Vector2Int squareCoords = layout.GetSquareCoordsAtIndex(i);
				Turn turn = layout.GetSquareTurnAtIndex(i);
				string typeName = layout.GetSquarePiaceNameAtIndex(i);
				//Debug.Log($"TypeName:{typeName}, Type:{typeName}");
				CreatePieceAndInitialize(squareCoords, turn, typeName);
			}
		}

		private void CreatePieceAndInitialize(Vector2Int squareCoords, Turn turn, string typeName)
		{
			Piece newPiece = _pieceCreator.CreatePiece(typeName).GetComponent<Piece>();
			newPiece.SetData(squareCoords, turn, _board);

			//Material turnMaterial = _pieceCreator.GetTurnMaterial(turn);
			//newPiece.SetMaterial(turnMaterial);
		}
	}
}