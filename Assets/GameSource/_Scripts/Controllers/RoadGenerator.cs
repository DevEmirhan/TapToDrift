using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoadPrefabs
{
    public GameObject prefab;
    public int roadId;
    public Vector3 offset;
    public bool hasPoint;
}


public class RoadGenerator : MonoBehaviour
{
    public List<RoadPrefabs> roads = new List<RoadPrefabs>();
    [SerializeField]
    private int roadLength;
    private Vector3 prevPos;
    private RoadPrefabs last;
    private bool isRightCond;
    private int helperCounter;
    private int roadValue;
    
    
    void Start()
    {
        
        for (int i = 0; i < roadLength; i++)
        {
            BuildRoad();
            helperCounter++;
        }
    }

    // Update is called once per frame
   
    private void BuildRoad()
    {
        if (helperCounter == 0)
        {
            prevPos = Vector3.zero;
            GameObject firstRoad = Instantiate(roads[0].prefab, prevPos, Quaternion.identity);
        }
         else if(helperCounter>0 && helperCounter <= 1)
        {
            GameObject curRoad = Instantiate(roads[0].prefab,prevPos + roads[0].offset, Quaternion.identity);
            prevPos = curRoad.transform.position;
            last = roads[0];
            
        } else if( helperCounter > 1 && helperCounter <= roadLength)
        {
            int randNum;
            if(last == roads[0])
            {
               
                randNum = Random.Range(2, 4);
                if(randNum == 2)
                {
                    GameObject curRoad = Instantiate(roads[2].prefab, prevPos + roads[0].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[2];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[3].prefab, prevPos + roads[0].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[3];
                }
            } else if(last == roads[1]) {
               

                if (isRightCond)
                {
                    randNum = Random.Range(0,2);
                    if(randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[4].prefab, prevPos + roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[4];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[6].prefab, prevPos + roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[6];
                    }
                }
                else
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[5].prefab, prevPos - roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[5];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[7].prefab, prevPos - roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[7];
                    }
                }            
            }
            else if( last == roads[2])
            {
                roadValue++;
                isRightCond = false;
                if(roadValue%15  != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, prevPos + roads[2].offset - new Vector3(30f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, prevPos + roads[2].offset - new Vector3(60f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[9];

                }
               
            } else if(last == roads[3])
            {
                roadValue++;
                isRightCond = true;
                if (roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, prevPos + roads[3].offset + new Vector3(30f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, prevPos + roads[3].offset + new Vector3(60f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[9];

                }
               
               
            } else if( last == roads[4])
            {
                roadValue++;
                if (roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[0].prefab, prevPos + roads[4].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[0];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[8].prefab, prevPos + roads[4].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[8];

                }
               
            }
            else if (last == roads[5])
            {
                roadValue++;
                if (roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[0].prefab, prevPos + roads[5].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[0];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[8].prefab, prevPos + roads[5].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[8];

                }
               
            }
            else if (last == roads[6])
            {
                roadValue++;
                isRightCond = false;
                if (roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, prevPos + roads[6].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, prevPos + roads[6].offset - new Vector3(30f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[9];

                }
              
            }
            else if (last == roads[7])
            {
                roadValue++;
                isRightCond = true;
                if (roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, prevPos + roads[7].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, prevPos + roads[6].offset + new Vector3(90f, 0f, 0f), Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[9];

                }
               
            }
            else if (last == roads[8])
            {
                randNum = Random.Range(2, 4);
                if (randNum == 2)
                {
                    GameObject curRoad = Instantiate(roads[2].prefab, prevPos + roads[8].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[2];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[3].prefab, prevPos + roads[8].offset, Quaternion.identity);
                    prevPos = curRoad.transform.position;
                    last = roads[3];
                }
            }
            else if (last == roads[9])
            {
                if (isRightCond)
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[4].prefab, prevPos + roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[4];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[6].prefab, prevPos + roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[6];
                    }
                }
                else
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[5].prefab, prevPos - roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[5];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[7].prefab, prevPos - roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        prevPos = curRoad.transform.position;
                        last = roads[7];
                    }
                }
            }
        }
    }
}
