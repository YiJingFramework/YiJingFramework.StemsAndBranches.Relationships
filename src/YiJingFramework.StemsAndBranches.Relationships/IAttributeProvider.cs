using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.StemsAndBranches.Relationships
{
    /// <summary>
    /// 表示一个可以提供某类对象某个属性的工具，例如地支的阴阳属性。
    /// Represents a tool which can provide a property of a kind of objects, such as the yin-yang attribute of the earthly branches.
    /// </summary>
    /// <typeparam name="TObject">
    /// 对象类型。
    /// Type of the objects.
    /// </typeparam>
    /// <typeparam name="TAttribute">
    /// 用以表示属性的类型。
    /// The type that represents the attribute.
    /// </typeparam>
    public interface IAttributeProvider<TObject, TAttribute>
    {
        /// <summary>
        /// 获取某个对象的属性。
        /// Get the attribute of a given object.
        /// </summary>
        /// <param name="obj">
        /// 对象。
        /// The object.
        /// </param>
        /// <returns>
        /// 属性。
        /// The attribute.
        /// </returns>
        TAttribute GetAttributeOf(TObject obj);
    }
}