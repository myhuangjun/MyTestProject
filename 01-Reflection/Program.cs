using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Reflection
{
    class Program
    {
        #region 知识点
        /*
         * 许多支持反射的类都位于System.Reflection命名空间中，所以在使用的反射的程序中一般都要使用 System.Reflection的命名空间。
            System.Type类包装了类型，因此是整个反射子系统的核心，这个类中包含了很多属性和方法，使用这些属性和方法可以在运行时得到类型的信息。
         * Type类派生于System.Reflection.MemberInfo抽象类
         * MemberInfo常用属性:
         * DeclaringType:获取声明该成员的类或接口的类型
         * MemberType:获取成员的类型，这个值用于指示该成员是字段、方法、属性、事件、或构造函数
         * Name:成员的名称
         * ReflectedType:反射的对象类型
         * 常用方法
         * GetCustomAttributes() ：获得与主调对象关联的自定义特性列表。
         * IsDefined(): 确定是否为主调对象定义了相应的特性。
         * GetCustomAttributesData():返回有关自定义特性的信息
         *
         * Type类属性;
         * Assembly:获取指定类型的程序集
         * Attributes:获取制定类型的特性
         * BaseType:获取指定类型的直接基类型
         * FullName:获取指定类型的全名
         * IsAbstract:是否为抽象类型
         * IsClass:是否为类
         * Namespace:获取指定类型的命名空间
         *
         * Type类方法:
         * GetConstructors():获取指定类型的构造函数列表
         * GetEvents();获取指定类型的事件列
         * GetFields();获取指定类型的字段列
         * GetMembers();获取指定类型的成员列表
         * GetMethods();获取指定类型的方法列表
         * GetProperties();获取指定类型的属性列表
         */
        #endregion
        static void Main(string[] args)
        {

        }
    }
}
