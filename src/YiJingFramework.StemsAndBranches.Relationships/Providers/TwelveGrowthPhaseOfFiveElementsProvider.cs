using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Core;
using YiJingFramework.FiveElements;
using static YiJingFramework.StemsAndBranches.Relationships.Providers.TwelveGrowthPhaseOfFiveElementsProvider;

namespace YiJingFramework.StemsAndBranches.Relationships.Providers
{
    /// <summary>
    /// 提供五行十二长生。
    /// Provides the twelve growth phase of five elements.
    /// 取木长生在亥、火长生在寅、金长生在巳、水土长生在申，顺行。
    /// It will use Hai as Wood's ZhangSheng, Yin as Fire's, Si as Metal's, Shen as Water's and Earth's,
    /// and then goes in direct motion for other growth phases.
    /// </summary>
    public class TwelveGrowthPhaseOfFiveElementsProvider : IRelationshipProvider<FiveElement, EarthlyBranch, TwelveGrowthPhase>
    {
        /// <summary>
        /// 十二长生。
        /// The twelve growth phase.
        /// </summary>
        public enum TwelveGrowthPhase
        {
            /// <summary>
            /// 长生。
            /// ZhangSheng.
            /// </summary>
            ZhangSheng = 0,
            /// <summary>
            /// 沐浴。
            /// MuYu.
            /// </summary>
            MuYu = 1,
            /// <summary>
            /// 冠带。
            /// GuanDai.
            /// </summary>
            GuanDai = 2,
            /// <summary>
            /// 临官。
            /// LinGuan.
            /// </summary>
            LinGuan = 3,
            /// <summary>
            /// 帝旺。
            /// DiWang.
            /// </summary>
            DiWang = 4,
            /// <summary>
            /// 衰。
            /// Shuai.
            /// </summary>
            Shuai = 5,
            /// <summary>
            /// 病。
            /// Bing.
            /// </summary>
            Bing = 6,
            /// <summary>
            /// 死。
            /// Si.
            /// </summary>
            Si = 7,
            /// <summary>
            /// 墓。
            /// Mu.
            /// </summary>
            Mu = 8,
            /// <summary>
            /// 绝。
            /// Jue.
            /// </summary>
            Jue = 9,
            /// <summary>
            /// 胎。
            /// Tai.
            /// </summary>
            Tai = 10,
            /// <summary>
            /// 养。
            /// Yang.
            /// </summary>
            Yang = 11
        }
        private static readonly IReadOnlyDictionary<FiveElement , EarthlyBranch> beginningBranches =
            new Dictionary<FiveElement, EarthlyBranch>()
            {
                { FiveElement.Wood, new EarthlyBranch(12) },
                { FiveElement.Fire, new EarthlyBranch(3) },
                { FiveElement.Metal, new EarthlyBranch(6) },
                { FiveElement.Water, new EarthlyBranch(9) },
                { FiveElement.Earth, new EarthlyBranch(9) },
            };

        /// <summary>
        /// 获取指定五行与地支的十二长生关系。
        /// Get the growth phase of the given element and branch.
        /// </summary>
        /// <param name="fiveElement">
        /// 五行。
        /// The five element.
        /// </param>
        /// <param name="branch">
        /// 地支。
        /// The earthly branch.
        /// </param>
        /// <returns>
        /// 关系。
        /// The relationship.
        /// </returns>
        public TwelveGrowthPhase GetRelationshipBetween(FiveElement fiveElement, EarthlyBranch branch)
        {
            return (TwelveGrowthPhase)((branch.Index - beginningBranches[fiveElement].Index + 12) % 12);
        }

        /// <summary>
        /// 获取与指定五行具有指定长生关系的地支。
        /// Get the branch which has the given growth phrase relationship with the given element.
        /// 必然返回且只返回一个地支。
        /// It will always return one and only branch.
        /// </summary>
        /// <param name="me">
        /// 五行。
        /// The five element.
        /// </param>
        /// <param name="relationship">
        /// 关系。
        /// The relationship.
        /// </param>
        /// <returns>
        /// 地支。
        /// The branch.
        /// </returns>
        public IEnumerable<EarthlyBranch> GetWithRelationship(FiveElement me, TwelveGrowthPhase relationship)
        {
            yield return new EarthlyBranch(beginningBranches[me].Index + (int)relationship);
        }
    }
}
