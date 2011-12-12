/****************************************************************************
Copyright (c) 2010-2011 cocos2d-x.org
Copyright (c) 2008-2010 Ricardo Quesada
Copyright (c) 2011 Zynga Inc.

http://www.cocos2d-x.org
http://www.openxlive.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace cocos2d
{
     
    public class CCTransitionFade : CCTransitionScene
    {
        const uint kSceneFade = 0xFADEFADE;
        protected ccColor4B m_tColor;

        /// <summary>
        /// creates the transition with a duration and with an RGB color
        /// Example: FadeTransition::transitionWithDuration(2, scene, ccc3(255,0,0); // red color
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="scene"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static CCTransitionFade transitionWithDuration(float duration, CCScene scene, ccColor3B color)
        {
            CCTransitionFade pTransition = new CCTransitionFade();
            pTransition.initWithDuration(duration, scene, color);
            return pTransition;
        }

        /// <summary>
        /// initializes the transition with a duration and with an RGB color 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="scene"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public virtual bool initWithDuration(float duration, CCScene scene, ccColor3B color)
        {
            if (base.initWithDuration(duration, scene))
            {
                m_tColor.r = color.r;
                m_tColor.g = color.g;
                m_tColor.b = color.b;
                m_tColor.a = 0;
            }
            return true;
        }

        public virtual bool initWithDuration(float t, CCScene scene)
        {
            this.initWithDuration(t, scene, new ccColor3B(Color.Black));
            return true;
        }
        public virtual void onEnter()
        {
            base.onEnter();

            CCLayerColor l = CCLayerColor.layerWithColor(m_tColor);
            m_pInScene.visible = false;

            //addChild(l, 2,kSceneFade);
            //CCNode f = getChildByTag(kSceneFade);

            CCActionInterval a = (CCActionInterval)CCSequence.actions
                (
                    CCFadeIn.actionWithDuration(m_fDuration / 2),
                    CCCallFunc.actionWithTarget(this, (base.hideOutShowIn)),//CCCallFunc::actionWithTarget:self selector:@selector(hideOutShowIn)],
                    CCFadeOut.actionWithDuration(m_fDuration / 2),
                    CCCallFunc.actionWithTarget(this, (base.finish)), //:self selector:@selector(finish)],
                    null
                );
            //f.runAction(a);
        }

        public virtual void onExit()
        {
            base.onExit();
            //this.removeChildByTag(kSceneFade, false);
        }
    }
}
