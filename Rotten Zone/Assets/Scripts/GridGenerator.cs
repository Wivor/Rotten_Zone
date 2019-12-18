using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int columnLen = 19;
    public int rowLen = 38;
    public float x_start = 0;
    public float z_start = 0;
    public float x_space = 5;
    public float z_space = 5;
    public GameObject background;
    public GameObject baseObject;
    public GameObject capPoint;
    public GameObject corridorCorner;
    public GameObject corridorCornerShort;
    public GameObject corridorStraight;
    public GameObject transparent;

    private GameObject[,] mapProto;
    private float[,] rotations;
    private Tuple<int, int> lastPoint;
    private bool[,,] corners;

    private static System.Random random;


    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        generateArray();
        /*for (int i = 0; i < columnLen * rowLen; i++)
        {
            Instantiate(preFab, new Vector3(x_start + (x_space * (i % columnLen)),1, z_start + (-z_space * (i / columnLen))), Quaternion.identity);
        }*/
        generateFromArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateFromArray()
    {
        for (int i = 0; i < columnLen; i++)
        {
            for (int j = 0; j < rowLen + 1; j++)
            {
                GameObject temp = Instantiate(mapProto[i, j]);
                temp.transform.parent = this.transform;
                temp.transform.position = new Vector3(x_start + (x_space * i), 0, z_start + (-z_space * j));
                temp.transform.Rotate(new Vector3(0,90f * rotations[i, j], 0));
                if (corners[i, j, 0])
                    FindObjectOfType<GameManager>().pathOne.Add(temp.transform);
                else if(corners[i,j,1])
                    FindObjectOfType<GameManager>().pathTwo.Add(temp.transform);
                else if(corners[i,j,2])
                    FindObjectOfType<GameManager>().pathThree.Add(temp.transform);

            }
        }
    }

    private void generateArray()
    {
        mapProto = new GameObject[columnLen, rowLen + 1];
        corners = new bool[columnLen, rowLen + 1, 3];
        rotations = new float[columnLen, rowLen + 1];
        for (int i = 0; i < columnLen; i++)
            for (int j = 0; j < rowLen; j++)
            {
                mapProto[i, j] = background;
                rotations[i, j] = 0f;
            }
        mapProto[columnLen / 2, 0] = baseObject;
        mapProto[columnLen / 2 + 1, 0] = baseObject;
        mapProto[columnLen / 2 + 2, 0] = baseObject;
        mapProto[columnLen / 2 - 1, 0] = baseObject;
        mapProto[columnLen / 2 - 2, 0] = baseObject;

        corners[columnLen / 2 - 2, 0, 0] = true;
        corners[columnLen / 2, 0, 1] = true;
        corners[columnLen / 2 + 2, 0, 2] = true;
        //mapProto[columnLen / 2, columnLen] = 7; //cap point

        lastPoint = Tuple.Create(columnLen / 2 - 2, 0);
        GeneratePoints(1, columnLen - 2, columnLen / 2 - 2, 0, 3, 1);
        lastPoint = Tuple.Create(columnLen / 2, 0);
        GeneratePoints(1, columnLen - 3, columnLen / 2 + 1, columnLen / 2 - 1, 1, 2);
        lastPoint = Tuple.Create(columnLen / 2 + 2, 0);
        GeneratePoints(1, columnLen - 2, columnLen, columnLen / 2 + 2, 2, 3);
        CreateCapPoint(columnLen / 2, columnLen, 1);
        for (int i = 0; i <= columnLen - 1; i++)
        {
            for (int j = 0; j <= rowLen/2 /*?? <= columnLen*/; j++)
            {
                if(mapProto[i, j] == corridorCorner)
                    mapProto[columnLen - i - 1, rowLen - j] = corridorCornerShort;
                else if (mapProto[i, j] == corridorCornerShort)
                    mapProto[columnLen - i - 1, rowLen - j] = corridorCorner;
                else
                    mapProto[columnLen - i - 1, rowLen - j] = mapProto[i, j];
                rotations[columnLen - i - 1, rowLen - j] = /*rotations[i, j] % 2 == 0 ?*/ rotations[i, j];// : -rotations[i,j];
            }
        }
    }

    private void GeneratePoints(int leftBorder, int rightBorder, int bottomBorder, int upperBorder, int amount, int laneID)
    {
        if (amount > rightBorder - leftBorder) throw new Exception("More points than columns");
        if (upperBorder >= bottomBorder) throw new Exception("Upper border can not be lower than bottom border");
        int spacePerBase = (rightBorder - leftBorder) / amount;
        int lastCol = 0;
        Stack<Tuple<int, int>> points = new Stack<Tuple<int, int>>();
        for (int i = 0; i < amount; i++)
        {
            int row = random.Next(upperBorder + 1, bottomBorder - 1);
            lastCol = random.Next(Math.Max(leftBorder + i * spacePerBase, lastCol + 5), leftBorder + (i + 1) * spacePerBase);
            Tuple<int, int> lastPos = Tuple.Create(row, lastCol);
            points.Push(lastPos);
            CreatePath(lastPoint, lastPos, bottomBorder, upperBorder, laneID);
            lastPoint = lastPos;
            //CreateCapPoint(random.Next(upperBorder + 1, bottomBorder - 1), lastCol);

        }
        CreatePath(lastPoint, Tuple.Create(columnLen / 2, columnLen - 1), bottomBorder, upperBorder, laneID);
        while (points.Count > 0)
        {
            Tuple<int, int> temp = points.Pop();
            CreateCapPoint(temp.Item1, temp.Item2, laneID);
        }
    }

    private void CreateCapPoint(int row, int col, int laneID)
    {
        for (int i = -1; i < 2; i++)
            for (int j = -1; j < 2; j++)
            {
                mapProto[row + i, col + j] = transparent;
                //corners[row + i, col + j, laneID-1] = false;
            }
        mapProto[row, col] = capPoint; //cap 
    }

    private void CreatePath(Tuple<int, int> startPoint, Tuple<int, int> endPoint, int bottomLimit, int upperLimit, int laneID)
    {
        int currentRow = startPoint.Item1;
        int currentCol = startPoint.Item2;
        //corners[currentRow, currentCol, laneID - 1] = true;
        //bool isMoveVertical = false;

        while (currentCol < endPoint.Item2)
        {
            int decision = random.Next(1, 100);
            if (decision < 50)
            {
                int distance = Math.Min(random.Next(2, 5), endPoint.Item2 - currentCol); //mniejszy limit górny = więcej zakrętów
                while (distance > 0)
                {
                    currentCol++;
                    mapProto[currentRow, currentCol] = corridorStraight;
                    rotations[currentRow, currentCol] = 2;
                    distance--;
                }
                //FindObjectOfType<GameManager>().pathOne.Add()
                //if (!isMoveVertical)
                //{
                //}
                //isMoveVertical = true;
            }
            /*else if (endPoint.Item2 - currentCol > 2 && isMoveVertical)
            {
                int distance = random.Next(upperLimit - currentRow, bottomLimit - currentRow);
                while (Math.Abs(distance) > 0)
                {
                    if (0 < currentRow + (Math.Sign(distance) * 2) && currentRow + (Math.Sign(distance) * 2) < columnLen && mapProto[currentRow + (Math.Sign(distance) * 2), currentCol] == baseObject) //zapobiega łączeniu
                    {
                        currentRow += Math.Sign(distance);
                        mapProto[currentRow, currentCol] = baseObject;//corridorStraight;
                        rotations[currentRow, currentCol] = 3;
                        distance -= Math.Sign(distance);
                    }
                    else break;
                }
                isMoveVertical = false;
                corners[currentRow, currentCol, laneID-1] = true;
            }*/
        }
        if (Math.Abs(currentRow - endPoint.Item1) >= 2)
        {
            if (currentRow - endPoint.Item1 > 0) 
            {
                rotations[currentRow, currentCol] = 2;
                mapProto[currentRow, currentCol] = corridorCorner;
            }
            else
            {
                rotations[currentRow, currentCol] = 1;
                mapProto[currentRow, currentCol] = corridorCornerShort;
            }
            corners[currentRow, currentCol, laneID - 1] = true;
            //2*Math.Sign(currentRow - endPoint.Item1);
            //if (currentRow < endPoint.Item1) { }
        }
        while (currentRow != endPoint.Item1)// && mapProto[currentRow-Math.Sign(currentRow - endPoint.Item1), currentCol] != 0)//Math.Abs(currentRow - endPoint.Item1) >2)
        {
            currentRow += Math.Sign(endPoint.Item1 - currentRow);
            rotations[currentRow, currentCol] = 3 * Math.Sign(currentRow - endPoint.Item1);
            mapProto[currentRow, currentCol] = corridorStraight;
        }
        corners[currentRow, currentCol, laneID - 1] = true;
    }

}
