using System;
using UnityEngine;


    // This is a simple class used in the maze scene
    // that determines when the character can be given
    // new target destinations.
    public class TargetSetting : MonoBehaviour {
       
        public event Action<Vector3> OnTargetSet;                     // This is triggered when a destination is set.

        [SerializeField] private AgentTrail m_AgentTrail;                               // This needs to know when a target has been set.
        [SerializeField] private UnityEngine.AI.NavMeshAgent m_AiCharacter;                                       // Used to actually set the destination of the player.

        private bool m_Active;                                          // This determines whether the character can be given targets or not.
        public float distance = 500f;



        //replace Update method in your class with this one
        void FixedUpdate () { 

            //if mouse button (left hand side) pressed instantiate a raycast
            if(Input.GetMouseButtonDown(0)) {
                //create a ray cast and set it to the mouses cursor position in game
                Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast (ray, out hit, distance))  {
                    //draw invisible ray cast/vector
                    Debug.DrawLine (ray.origin, hit.point);
                    //log hit area to the console
                    Debug.Log(hit.point);
                    OnTargetSet(hit.point);
                    m_AgentTrail.SetDestination();
                    m_AiCharacter.SetDestination(hit.point);

                }    
            }    
        }


    
    }
