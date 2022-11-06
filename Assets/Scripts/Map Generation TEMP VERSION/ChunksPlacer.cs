using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Linq;

public class ChunksPlacer : MonoBehaviour
{
    [SerializeField] private Chunk[] chunksPrefabs;
    [SerializeField] private List<Chunk> displayedСhunks = new List<Chunk>(7);
    [SerializeField] private Transform character;
   // [SerializeField] private float visibilityRange = 15;

    public List<Chunk> chunksСreated = new List<Chunk>();

    private void Start()
        => SpawnChunck(chunksPrefabs[Random.Range(0, chunksPrefabs.Length)]);

    private void Update()
    {
        var _middleChunk = displayedСhunks[displayedСhunks.Count / 2];

        if (character.position.z > _middleChunk.transform.position.z)
        {
            SpawnChunck(chunksPrefabs[Random.Range(0, chunksPrefabs.Length)]);

            if (displayedСhunks.Count > 7)
                displayedСhunks.RemoveAt(0);
        }

    }

    private void SpawnChunck(Chunk chunk)
    {
        var _offset = displayedСhunks.Last().Lenght / 2 + chunk.Lenght / 2;
        var _newChunckPosition = new Vector3(0, 0, displayedСhunks.Last().transform.position.z + _offset);

        foreach (var _chunck in chunksСreated)
        {
            if (_chunck.TypeId == chunk.TypeId && !displayedСhunks.Contains(_chunck))
            {
                _chunck.transform.position = _newChunckPosition;
                displayedСhunks.Add(_chunck);
                return;
            }
        }

        var createdChunk = Instantiate(chunk, _newChunckPosition, Quaternion.identity);
        createdChunk.transform.SetParent(transform);
        displayedСhunks.Add(createdChunk);
        chunksСreated.Add(createdChunk);
    }
}