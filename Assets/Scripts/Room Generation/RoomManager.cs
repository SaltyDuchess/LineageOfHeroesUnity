using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	public static RoomManager Instance;
	public GameObject doorPrefab;
	public GameObject wallPrefab;
	public GameObject roomPrefab;
	public int roomSize = 20;

	private float wallWidth;
	private float wallHeight;
	private Player player;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			player = FindObjectOfType<Player>();
			InitializeWallSize();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void InitializeWallSize()
	{
		if (wallPrefab != null)
		{
			GameObject tempWall = Instantiate(wallPrefab);
			SpriteRenderer wallRenderer = tempWall.GetComponentInChildren<SpriteRenderer>();
			if (wallRenderer != null)
			{
				wallWidth = wallRenderer.bounds.size.x;
				wallHeight = wallRenderer.bounds.size.y;
			}
			else
			{
				Debug.LogError("Wall prefab does not have a SpriteRenderer component.");
			}
			Destroy(tempWall);
		}
		else
		{
			Debug.LogError("Wall prefab is not assigned.");
		}
	}

	public void GenerateNewRoom(DoorController.DoorOrientation entryOrientation)
	{
		Vector3 roomOffset = CalculateRoomOffset(entryOrientation);

		// Instantiate a new Room object
		GameObject newRoomObject = Instantiate(roomPrefab, player.transform.position + roomOffset / 2, Quaternion.identity);
		Room newRoom = newRoomObject.GetComponent<Room>();
		newRoom.Initialize(new Vector2Int(roomSize, roomSize));

		GenerateDoors(entryOrientation, roomOffset, newRoom);
		GenerateWalls(entryOrientation, roomOffset, newRoom);

		FindObjectOfType<SpawnController>().SpawnEnemiesInRoom(newRoom);
	}

	private Vector3 CalculateRoomOffset(DoorController.DoorOrientation entryOrientation)
	{
		switch (entryOrientation)
		{
			case DoorController.DoorOrientation.North:
				return new Vector3(0, roomSize, 0);
			case DoorController.DoorOrientation.South:
				return new Vector3(0, -roomSize, 0);
			case DoorController.DoorOrientation.East:
				return new Vector3(roomSize, 0, 0);
			case DoorController.DoorOrientation.West:
				return new Vector3(-roomSize, 0, 0);
			default:
				return Vector3.zero;
		}
	}

	private void GenerateDoors(DoorController.DoorOrientation entryOrientation, Vector3 roomOffset, Room room)
	{
		Vector3[] doorPositions;
		DoorController.DoorOrientation[] doorOrientations;

		switch (entryOrientation)
		{
			case DoorController.DoorOrientation.North:
				doorPositions = new Vector3[]
				{
										new Vector3(player.transform.position.x, player.transform.position.y + roomSize, 0), // Top
                    new Vector3(player.transform.position.x + roomSize / 2, player.transform.position.y + roomSize / 2, 0), // Right
                    new Vector3(player.transform.position.x - roomSize / 2, player.transform.position.y + roomSize / 2, 0), // Left
				};
				doorOrientations = new DoorController.DoorOrientation[]
				{
										DoorController.DoorOrientation.North,
										DoorController.DoorOrientation.East,
										DoorController.DoorOrientation.West
				};
				break;

			case DoorController.DoorOrientation.South:
				doorPositions = new Vector3[]
				{
										new Vector3(player.transform.position.x, player.transform.position.y - roomSize, 0), // Bottom
                    new Vector3(player.transform.position.x + roomSize / 2, player.transform.position.y - roomSize / 2, 0), // Right
                    new Vector3(player.transform.position.x - roomSize / 2, player.transform.position.y - roomSize / 2, 0), // Left
				};
				doorOrientations = new DoorController.DoorOrientation[]
				{
										DoorController.DoorOrientation.South,
										DoorController.DoorOrientation.East,
										DoorController.DoorOrientation.West
				};
				break;

			case DoorController.DoorOrientation.East:
				doorPositions = new Vector3[]
				{
										new Vector3(player.transform.position.x + roomSize / 2, player.transform.position.y + roomSize / 2, 0), // Top
                    new Vector3(player.transform.position.x + roomSize, player.transform.position.y, 0), // Right
                    new Vector3(player.transform.position.x + roomSize / 2, player.transform.position.y - roomSize / 2, 0), // Bottom
				};
				doorOrientations = new DoorController.DoorOrientation[]
				{
										DoorController.DoorOrientation.North,
										DoorController.DoorOrientation.East,
										DoorController.DoorOrientation.South
				};
				break;

			case DoorController.DoorOrientation.West:
				doorPositions = new Vector3[]
				{
										new Vector3(player.transform.position.x - roomSize / 2, player.transform.position.y + roomSize / 2, 0), // Top
                    new Vector3(player.transform.position.x - roomSize, player.transform.position.y, 0), // Left
                    new Vector3(player.transform.position.x - roomSize / 2, player.transform.position.y - roomSize / 2, 0), // Bottom
				};
				doorOrientations = new DoorController.DoorOrientation[]
				{
										DoorController.DoorOrientation.North,
										DoorController.DoorOrientation.West,
										DoorController.DoorOrientation.South
				};
				break;
			default:
				doorPositions = new Vector3[0];
				doorOrientations = new DoorController.DoorOrientation[0];
				break;
		}

		HashSet<DoorController.DoorOrientation> generatedOrientations = new HashSet<DoorController.DoorOrientation>();

		for (int i = 0; i < doorPositions.Length; i++)
		{
			if (!generatedOrientations.Contains(doorOrientations[i]))
			{
				GameObject door = Instantiate(doorPrefab, doorPositions[i], Quaternion.identity, room.transform);
				door.tag = "Door";
				door.GetComponent<DoorController>().orientation = doorOrientations[i];
				if (doorOrientations[i] == DoorController.DoorOrientation.East || doorOrientations[i] == DoorController.DoorOrientation.West)
				{
					door.transform.rotation = Quaternion.Euler(0, 0, 90);
				}
				room.AddDoor(door);
				generatedOrientations.Add(doorOrientations[i]);
			}
		}
	}

	private void GenerateWalls(DoorController.DoorOrientation entryOrientation, Vector3 roomOffset, Room room)
	{
		if (wallWidth == 0 || wallHeight == 0)
		{
			Debug.LogError("Wall dimensions are not properly set.");
			return;
		}

		int horizontalSegments = Mathf.CeilToInt(roomSize / wallWidth);
		int verticalSegments = Mathf.CeilToInt(roomSize / wallHeight);

		for (int i = -horizontalSegments / 2; i <= horizontalSegments / 2; i++)
		{
			for (int j = -verticalSegments / 2; j <= verticalSegments / 2; j++)
			{
				Vector3 position = new Vector3(i * wallWidth, j * wallHeight, 0) + roomOffset / 2 + player.transform.position;

				bool isEdgePosition = i == -horizontalSegments / 2 || i == horizontalSegments / 2 || j == -verticalSegments / 2 || j == verticalSegments / 2;

				bool shouldGenerateWall = ShouldGenerateWall(entryOrientation, i, j, horizontalSegments, verticalSegments);

				if (isEdgePosition && shouldGenerateWall)
				{
					if (!IsPositionOccupiedByDoor(position, room))
					{
						Instantiate(wallPrefab, position, Quaternion.identity, room.transform).tag = "Wall";
					}
				}
			}
		}
	}

	private bool ShouldGenerateWall(DoorController.DoorOrientation entryOrientation, int i, int j, int horizontalSegments, int verticalSegments)
	{
		switch (entryOrientation)
		{
			case DoorController.DoorOrientation.North:
				if (j == -verticalSegments / 2) return false;
				break;
			case DoorController.DoorOrientation.South:
				if (j == verticalSegments / 2) return false;
				break;
			case DoorController.DoorOrientation.East:
				if (i == -horizontalSegments / 2) return false;
				break;
			case DoorController.DoorOrientation.West:
				if (i == horizontalSegments / 2) return false;
				break;
		}
		return true;
	}

	private bool IsPositionOccupiedByDoor(Vector3 position, Room room)
	{
		foreach (var door in room.GetDoors())
		{
			if (Vector3.Distance(position, door.transform.position) <= Mathf.Max(wallWidth, wallHeight))
			{
				return true;
			}
		}
		return false;
	}
}
