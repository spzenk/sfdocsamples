using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Drawing;

namespace Allus.Cnn.Common.BE
{
    [XmlRoot("MarqueeBE"), SerializableAttribute]
    public class MarqueeBE : Entity
    {
        private Position mPosition;
        private Direction mDirection;
        private Int32 mColor;
        private Int32 mDigitCount;
        private Int32 mTimeToShow;
        private String mShape;
        private Int32 mSpeed;
        private String mTextToShow;
        private Int32 mTextoLinkColor;
        private String mTextLink;


        public String TextLink
        {
            get
            {
                return mTextLink;
            }
            set
            {
                mTextLink = value;
            }
        }

        public Int32 TextoLinkColor
        {
            get
            {
                return mTextoLinkColor;
            }
            set
            {
                mTextoLinkColor = value;
            }
        }

        public String TextToShow
        {
            get
            {
                return mTextToShow;
            }
            set
            {
                mTextToShow = value;
            }
        }

        public String Shape
        {
            get
            {
                return mShape;
            }
            set
            {
                mShape = value;
            }
        }

        public Int32 DigitCount
        {
            get
            {
                return mDigitCount;
            }
            set
            {
                mDigitCount = value;
            }
        }

        public Int32 Color
        {
            get
            {
                return mColor;
            }
            set
            {
                mColor = value;
            }
        }
        
        public Int32 Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; }
        }        

        public Direction Direction
        {
            get { return mDirection; }
            set { mDirection = value; }
        }

        public Position Position
        {
            get { return mPosition; }
            set { mPosition = value; }
        }

        public Int32 TimeToShow
        {
            get { return mTimeToShow; }
            set { mTimeToShow = value; }
        }
                       
    }
}







	