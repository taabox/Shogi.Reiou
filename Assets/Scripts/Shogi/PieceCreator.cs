using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shogi.Reiou
{
	public class PieceCreator : MonoBehaviour
	{
		[SerializeField] private GameObject[] _piecePrefabs;
		[SerializeField] private Transform _deployParentObject;

		private Dictionary<string, GameObject> _nameToPieceDict = new Dictionary<string, GameObject>();

		private void Awake()
		{
			foreach (var piece in _piecePrefabs)
			{
				string name = piece.GetComponent<Piece>().Type.ToString();
				_nameToPieceDict.Add(name, piece);
				//Debug.Log($"PieceのTypeName:{name}");
			}
		}

		public GameObject CreatePiece(string typeName)
		{
			//Debug.Log($"これから作るTypeName:{typeName}");
			GameObject prefab = _nameToPieceDict[typeName];
			if (prefab)
			{
				GameObject newPiece = Instantiate(prefab, _deployParentObject);
				//newPiece.transform.position = new Vector3(0, 0, 0);
				return prefab;
			}
			return null;
		}
	}
}