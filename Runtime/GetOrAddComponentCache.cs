using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// GetComponent か AddComponent の結果をキャッシュしておくためのクラス
    /// </summary>
    public sealed class GetOrAddComponentCache<T> where T : Component
    {
        private T    m_cache;
        private bool m_isCached;

        public T Get<TComponent>( TComponent component ) where TComponent : Component
        {
            return Get( component.gameObject );
        }

        public T Get( GameObject gameObject )
        {
            // UnityEngine.Object の null チェックは少し負荷がかかるため
            // bool 値で判定するようにしています
            if ( m_isCached ) return m_cache;
            if ( m_cache != null ) return m_cache;

            m_cache = gameObject.GetComponent<T>();

            if ( m_cache == null )
            {
                m_cache = gameObject.AddComponent<T>();
            }

            m_isCached = m_cache != null;

            return m_cache;
        }
    }
}