using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.StemsAndBranches.Relationships
{
    /// <summary>
    /// 表示一个可以判断或提供两类对象直接关系的工具，例如十二长生关系。
    /// Represents a tool which can judge or provide the relationship between two kinds of objects, such as the twelve growth phase.
    /// </summary>
    /// <typeparam name="TMe">
    /// 作为标准的对象的类型，例如五行。
    /// Type of the objects which will be used as the standard, such as the five elements.
    /// </typeparam>
    /// <typeparam name="TAnother">
    /// 被判断的对象的类型，例如地支。
    /// Type of the objects to be judged, such as the earthly branches.
    /// </typeparam>
    /// <typeparam name="TRelationship">
    /// 用以表示关系的类型。
    /// The type that represents the relationship.
    /// </typeparam>
    public interface IRelationshipProvider<TMe, TAnother, TRelationship>
    {
        /// <summary>
        /// 获取两个对象之间的关系。
        /// Get the relationship between the two objects.
        /// </summary>
        /// <param name="me">
        /// 作为标准的对象。
        /// The object which will be used as the standard.
        /// </param>
        /// <param name="another">
        /// 被判断的对象。
        /// The object to be judged.
        /// </param>
        /// <returns>
        /// 两者关系。
        /// The relationship.
        /// </returns>
        TRelationship? GetRelationshipBetween(TMe me, TAnother another);
        /// <summary>
        /// 获取对于标准对象有某种关系的所有对象。
        /// Get all the objects which have the given relationship with the standard object.
        /// </summary>
        /// <param name="me">
        /// 作为标准的对象。
        /// The object which will be used as the standard.
        /// </param>
        /// <param name="relationship">
        /// 其关系。
        /// The relationship.
        /// </param>
        /// <returns>
        /// 所有对象。
        /// All the objects.
        /// </returns>
        IEnumerable<TAnother> GetWithRelationship(TMe me, TRelationship relationship);
    }
}