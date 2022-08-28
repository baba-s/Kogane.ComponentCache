# Kogane Component Cache

GetComponent の結果をキャッシュしておくためのクラス

# 使用例

## Before

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

## After

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private ComponentCache<Rigidbody> m_rigidbodyCache;

    public Rigidbody rigidbody => m_rigidbodyCache.Get( gameObject );

    private void Awake()
    {
        Debug.Log( rigidbody );
    }
}
```