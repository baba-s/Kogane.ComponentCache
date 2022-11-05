using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// GetComponentInChildren の結果をキャッシュしておくためのクラス
    /// </summary>
    public sealed class GetComponentInChildrenOrAddCache<T> where T : Component
    {
        private T    m_cache;
        private bool m_isCached;

        public T Get<TComponent>( TComponent component, bool includeInactive = true ) where TComponent : Component
        {
            return Get( component.gameObject, includeInactive );
        }

        public T Get( GameObject gameObject, bool includeInactive = true )
        {
            // UnityEngine.Object の null チェックは少し負荷がかかるため
            // bool 値で判定するようにしています
            if ( m_isCached ) return m_cache;
            if ( m_cache != null ) return m_cache;

            m_cache = gameObject.GetComponentInChildren<T>( includeInactive );

            if ( m_cache == null )
            {
                m_cache = gameObject.AddComponent<T>();
            }

            m_isCached = m_cache != null;

            return m_cache;
        }
    }
}