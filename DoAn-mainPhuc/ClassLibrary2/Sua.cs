using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Sua
    {
        public static void UpdateEntity<T>(T source, T target,params string[] ignoreProperties)
        {
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {

                // Bỏ qua nếu thuộc tính nằm trong danh sách cấm của bạn
                if (ignoreProperties.Contains(prop.Name)) continue;

                // Mẹo: Kiểm tra nếu thuộc tính là class (không phải string/int/date) thì thường là bảng quan hệ
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string)) continue;

                var value = prop.GetValue(source);
                prop.SetValue(target, value);
            }
        }
    }
}
