using UnityEngine;
using System.Collections;

public static class TransformDeepFind
 {
    //The recursive definition of DFS and BFS
     //Breadth-first search
      //Prefer this method over the other!!!
      public static Transform FindDeepChildBFS(this Transform parent, string name) {
          var result = parent.Find(name);
          if (result != null)
              return result;
          foreach (Transform child in parent) {
              result = child.FindDeepChildBFS(name);
              if (result != null) {
                  return result;
              }
          }
          return null;
      }

   
        //Depth First Search
        public static Transform FindDeepChildDFS(this Transform parent, string name){
            foreach(Transform child in parent){
                if(child.name == name )
                    return child;
                var result = child.FindDeepChildDFS(name);
                if (result != null)
                    return result;
            }
            return null;
        }
    
    }