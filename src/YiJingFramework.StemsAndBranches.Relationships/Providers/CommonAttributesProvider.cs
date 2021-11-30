using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Core;
using YiJingFramework.FiveElements;

namespace YiJingFramework.StemsAndBranches.Relationships.Providers
{
    /// <summary>
    /// 提供常见干支属性。
    /// Provides the commonly used attributes for stems and branches.
    /// 包括阴阳和五行属性，具体见 <seealso cref="GetAttributeOf(HeavenlyStem)"/> 和 <seealso cref="GetAttributeOf(EarthlyBranch)"/> 。
    /// Includes yin-yang and five elements attributes, see <seealso cref="GetAttributeOf(HeavenlyStem)"/> and <seealso cref="GetAttributeOf(EarthlyBranch)"/> for more details.
    /// </summary>
    public class CommonAttributesProvider : 
        IAttributeProvider<HeavenlyStem, YinYang>, IAttributeProvider<HeavenlyStem, FiveElement>,
        IAttributeProvider<EarthlyBranch,YinYang>, IAttributeProvider<EarthlyBranch,FiveElement>
    {
        /// <summary>
        /// 获取指定天干的阴阳五行。
        /// Get the yin-yang and five elements attributes of a given heavenly stem.
        /// 取甲阳木、乙阴木、丙阳火、丁阴火、戊阳土、己阴土、庚阳金、辛阴金、壬阳水、癸阴水。
        /// It will use Jia-Yang-Wood, Yi-Yin-Wood, Bing-Yang-Fire, Ding-Yin-Fire, Wu-Yin-Earth, 
        /// Ji-Yin-Earth, Geng-Yang-Metal, Xin-Yin-Metal, Ren-Yang-Water, Gui-Yin-Water.
        /// </summary>
        /// <param name="stem">
        /// 天干。
        /// The heavenly stem.
        /// </param>
        /// <returns>
        /// 阴阳五行属性。
        /// The yin-yang and five elements attributes.
        /// </returns>
        public (YinYang, FiveElement) GetAttributeOf(HeavenlyStem stem)
        {
            return (
                ((IAttributeProvider<HeavenlyStem, YinYang>)this).GetAttributeOf(stem),
                ((IAttributeProvider<HeavenlyStem, FiveElement>)this).GetAttributeOf(stem)
                );
        }

        FiveElement IAttributeProvider<HeavenlyStem, FiveElement>.GetAttributeOf(HeavenlyStem stem)
        {
            return (FiveElement)(stem.Index / 2);
        }

        YinYang IAttributeProvider<HeavenlyStem, YinYang>.GetAttributeOf(HeavenlyStem stem)
        {
            return (YinYang)(stem.Index % 2);
        }

        /// <summary>
        /// 获取指定地支的阴阳五行。
        /// Get the yin-yang and five elements attributes of a given earthly branch.
        /// 取寅卯木、巳午火、申酉金、亥子水、辰戌丑未土。
        /// It will use Wood(Yin, Mao), Fire(Si, Wu), Metal(Shen, You), Water(Hai, Zi), Earth(Chen, Xu, Chou, Wei).
        /// 取子寅辰午申戌阳，丑卯巳未酉亥阴。
        /// It will use Yang(Zi, Yin, Chen, Wu, Shen, Xu), Yin(Chou, Mao, Si, Wei, You, Hai).
        /// </summary>
        /// <param name="branch">
        /// 地支。
        /// The earthly branch.
        /// </param>
        /// <returns>
        /// 阴阳五行属性。
        /// The yin-yang and five elements attributes.
        /// </returns>
        public (YinYang, FiveElement) GetAttributeOf(EarthlyBranch branch)
        {
            return (
                ((IAttributeProvider<EarthlyBranch,YinYang>)this).GetAttributeOf(branch),
                ((IAttributeProvider<EarthlyBranch, FiveElement>)this).GetAttributeOf(branch)
                );
        }

        FiveElement IAttributeProvider<EarthlyBranch, FiveElement>.GetAttributeOf(EarthlyBranch branch)
        {
            if (branch.Index % 3 == 2)
                return FiveElement.Earth;

            return (branch.Index / 3) switch
            {
                0 or 4 => FiveElement.Water,
                1 => FiveElement.Wood,
                2 => FiveElement.Fire,
                _ => FiveElement.Metal // 3
            };
        }

        YinYang IAttributeProvider<EarthlyBranch, YinYang>.GetAttributeOf(EarthlyBranch branch)
        {
            return (YinYang)(branch.Index % 2);
        }
    }
}
