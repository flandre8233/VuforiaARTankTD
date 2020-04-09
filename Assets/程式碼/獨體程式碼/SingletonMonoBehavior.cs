using UnityEngine;
using System.Collections;

public abstract class SingletonMonoBehavior<T> : MonoBehaviour {
    //獨體設定，唯一程式就可以掛載繼承他
    private static T _instance;

    public virtual void Awake() {
        if (_instance == null || _instance.Equals(default(T)))
            _instance = (T)((System.Object)this);
    }

    public static T instance {
        get { return _instance; }
    }

}

