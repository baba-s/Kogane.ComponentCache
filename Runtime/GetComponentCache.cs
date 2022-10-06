using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// GetComponent の結果をキャッシュしておくためのクラス
    /// </summary>
    public sealed class GetComponentCache<T>
    {
        private T    m_cache;
        private bool m_isCached;

        public T Get( Component component )
        {
            return Get( component.gameObject );
        }

        public T Get( GameObject gameObject )
        {
            // UnityEngine.Object の null チェックは少し負荷がかかるため
            // bool 値で判定するようにしています
            if ( m_isCached ) return m_cache;
            if ( m_cache != null ) return m_cache;

            m_cache    = gameObject.GetComponent<T>();
            m_isCached = m_cache != null;

            return m_cache;
        }
    }
}