using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrees : MonoBehaviour {

    public GameObject[] Trees = new GameObject[3];
    private GameObject _currentTree;

    private float SphereRadius;
    public GameObject World;

    public int numberOfTrees;
    

    public void Start () {
        SphereRadius = World.GetComponent<SphereCollider>().radius * World.transform.localScale.x;

        for(int i = 0; i < numberOfTrees; i++)
        {
            Debug.Log("Spawn tree");
            MakeTree();        
        }
    }

    void MakeTree()
    {

        bool cont = true;
        do
        {
            Vector3 randomVec = Random.onUnitSphere;
            Ray ray = new Ray(World.transform.position, randomVec);
            Vector3 newPos = ray.GetPoint(SphereRadius + 1);



            _currentTree = Instantiate(Trees[Random.Range(0,3)], newPos, Quaternion.Euler(0,0,0)) as GameObject;
            _currentTree.transform.Rotate(-randomVec);

            _currentTree.transform.SetParent(this.transform);
            

            Collider[] botsing = Physics.OverlapBox(_currentTree.transform.position, new Vector3(0.5f, 0.5f, 0.5f), _currentTree.transform.rotation);
            cont = false;
            for (int b = 0; b < botsing.Length; ++b)
            {
                if (botsing[b].gameObject != _currentTree.gameObject) cont = true;
                Debug.Log("botsts met " + botsing[b].gameObject.name);
            }

        }
        while (cont);

    }
	
	
}
