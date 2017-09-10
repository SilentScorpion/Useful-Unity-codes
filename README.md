# Useful-Unity-codes

GameObject.Find() is used for referencing Objects in the scene. However, it is a very expensive operation as it involves a linear search till the object is found. GameObject.Find() cannot find inactive objects. (Something that is highly used in this problem domain.) As a result, the only option available to use to reference it inside the script is using the drag & drop method in the hierarchy.

I generally prefer using transform.Find(), which is not as expensive as GameObject.Find(). It also works on inactive objects and returns their transform as well

Transform.Find() however returns only the immediate children of the GameObject.transform and cannot go inside its successors.
This extension method uses BFS/DFS technique to traverse through all the successors of a given GameObject transform and return the needed transform


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
        
2. I generally prefer using the given Vibration class methods instead of Handheld.Vibrate(long milliseconds)
