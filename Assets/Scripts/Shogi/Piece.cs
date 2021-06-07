using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Shogi.Reiou
{
	[RequireComponent(typeof(IObjectTweener))]
	//[RequireComponent(typeof(MaterialSetter))]
	public abstract class Piece : MonoBehaviour
	{
		public Board Board { protected get; set; }

		[SerializeField, ReadOnly] private Vector2Int _occupiedSquare;
		public Vector2Int OccupiedSquare => _occupiedSquare;

		[SerializeField, ReadOnly] private Turn _turn;
		public Turn Turn => _turn;

		[SerializeField, ReadOnly] private bool _hasMoved;
		public bool HasMoved => _hasMoved;

		[SerializeField, ReadOnly] private List<Vector2Int> _avaliableMoves;
		public List<Vector2Int> AvaliableMoves => _avaliableMoves;

		[SerializeField] private PieceType _type;
		public PieceType Type => _type;

		public abstract List<Vector2Int> SelectAvaliableSquares();

		readonly Vector3 SENTE_OMOTE_ROTATE = new Vector3(-90, 180, 0);
		readonly Vector3 SENTE_URA_ROTATE = new Vector3(90, 0, 0);
		readonly Vector3 GOTE_OMOTE_ROTATE = new Vector3(-90, 0, 0);
		readonly Vector3 GOTE_URA_ROTATE = new Vector3(90, 180, 0);



		//private MaterialSetter _materialSetter;
		private IObjectTweener _tweener;

		private void Awake()
		{
			_avaliableMoves = new List<Vector2Int>();
			//_materialSetter = GetComponent<MaterialSetter>();
			_tweener = GetComponent<IObjectTweener>();
			_hasMoved = false;
		}

		//public void SetMaterial(Material material)
		//{
		//	_materialSetter.SetSingleMaterial(material);
		//}

		public bool IsFromSameTurn(Piece piece)
		{
			return Turn == piece.Turn;
		}

		public bool CanMoveTo(Vector2Int coords)
		{
			return AvaliableMoves.Contains(coords);
		}

		public virtual void MovePiece(Vector2Int coords)
		{

		}

		protected void TryToAddMove(Vector2Int coords)
		{
			AvaliableMoves.Add(coords);
		}

		public void SetData(Vector2Int coords, Turn turn, Board board)
		{
			_turn = turn;
			_occupiedSquare = coords;
			this.Board = board;
			transform.position = board.CalculatePositionFromCoords(coords);
			transform.SetAsFirstSibling();
			SetRotation();
			Debug.Log($"{Turn}, {Type}, {OccupiedSquare}, {transform.position}");
		}

		public void SetRotation()
		{
			if (_turn == Turn.Sente)
				transform.rotation = Quaternion.Euler(SENTE_OMOTE_ROTATE);
			else
				transform.rotation = Quaternion.Euler(GOTE_OMOTE_ROTATE);
		}
	}
}
