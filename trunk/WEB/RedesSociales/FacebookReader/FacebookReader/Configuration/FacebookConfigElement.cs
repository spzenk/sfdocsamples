using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Facebook.Configuration
{
    public class FacebookProvider : ConfigurationElement
    {
        public FacebookProvider() { }

        /// <summary>
        /// Nombre clave del elemento, este valor debe ser unico.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        /// <summary>
        /// Identificador del muro a leer.
        /// </summary>
        [ConfigurationProperty("sourceId", IsRequired = true)]
        public long SourceId
        {
            get
            {
                return (long)this["sourceId"];
            }
        }

        /// <summary>
        /// Identificador del usuario.
        /// </summary>
        [ConfigurationProperty("userId", IsRequired = true, IsKey = false)]
        public string UserId
        {
            get
            {
                return (string)this["userId"];
            }
        }

        /// <summary>
        /// Access token de lectura.
        /// </summary>
        [ConfigurationProperty("userAccessToken", IsRequired = true, IsKey = false)]
        public string UserAccessToken
        {
            get
            {
                return (string)this["userAccessToken"];
            }
        }

        /// <summary>
        /// Access token de escritura.
        /// </summary>
        [ConfigurationProperty("pageAccessToken", IsRequired = false, IsKey = false)]
        public string PageAccessToken
        {
            get
            {
                return (string)this["pageAccessToken"];
            }
        }

        /// <summary>
        /// Determina si el elemento esta habilitado.
        /// </summary>
        [ConfigurationProperty("enabled", IsRequired = true, IsKey = false, DefaultValue = true)]
        public bool Enabled
        {
            get
            {
                return (bool)this["enabled"];
            }
        }
    }
}