using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Twitter.Configuration
{
    public class TwitterConfigElement : ConfigurationElement
    {
        public TwitterConfigElement() { }

        /// <summary>
        /// Nombre del elemento, este valor debe ser unico.
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
        /// Access token de acceso del usuario.
        /// </summary>
        [ConfigurationProperty("accessToken", IsRequired = true)]
        public string AccessToken
        {
            get
            {
                return (string)this["accessToken"];
            }
        }

        /// <summary>
        /// Clave del Access token de acceso del usuario.
        /// </summary>
        [ConfigurationProperty("accessTokenSecret", IsRequired = true)]
        public string AccessTokenSecret
        {
            get
            {
                return (string)this["accessTokenSecret"];
            }
        }

        /// <summary>
        /// Determina si el elemento esta habilitado.
        /// </summary>
        [ConfigurationProperty("enabled", IsRequired = true, DefaultValue = true)]
        public bool Enabled
        {
            get
            {
                return (bool)this["enabled"];
            }
        }
    }
}