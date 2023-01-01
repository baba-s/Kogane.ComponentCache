# Kogane Component Cache

GetComponent の結果をキャッシュしておくためのクラス

## 使用例

### Before

```cs
using UnityEngine;

public class Example : MonoBehaviour
{
    private Rigidbody m_rigidbodyCache;

    public Rigidbody rigidbody
    {
        get
        {
            if ( m_rigidbodyCache == null )
            {
                m_rigidbodyCache = GetComponent<Rigidbody>();
            }

            return m_rigidbodyCache;
        }
    }

    private void Awake()
    {
        Debug.Log( rigidbody );
    }
}
```

### After

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private readonly GetComponentCache<Rigidbody> m_rigidbodyCache = new ();

    public Rigidbody rigidbody => m_rigidbodyCache.Get( gameObject );

    private void Awake()
    {
        Debug.Log( rigidbody );
    }
}
```

## 種類

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private readonly GetComponentCache<Rigidbody>                m_cache1 = new ();
    private readonly GetComponentInChildrenCache<Rigidbody>      m_cache2 = new ();
    private readonly GetComponentInChildrenOrAddCache<Rigidbody> m_cache3 = new ();
    private readonly GetOrAddComponentCache<Rigidbody>           m_cache4 = new ();
}
```