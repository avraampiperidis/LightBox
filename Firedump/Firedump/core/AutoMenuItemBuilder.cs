using FastColoredTextBoxNS;
using Firedump.core.sql;
using Firedump.models;
using System.Collections.Generic;

namespace Firedump.core
{
    public class AutoMenuItemBuilder
    {
        internal static List<AutocompleteItem> SqlCommands()
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            foreach (string s in Words.SQL)
            {
                list.Add(new AutocompleteItem(s) { ImageIndex = (int)FinalImageIndex.Sql });
            }
            return list;
        }

        internal static List<AutocompleteItem> PlSqlCommands()
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            foreach (string s in Words.PL_SQL)
            {
                list.Add(new AutocompleteItem(s) { ImageIndex = (int)FinalImageIndex.Function });
            }
            return list;
        }

        internal static List<AutocompleteItem> JoinCommands()
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            list.Add(new AutocompleteItem() { Text = Words.INNER_JOIN, MenuText = "INNER JOIN", ImageIndex = (int)FinalImageIndex.InnerJoin });
            list.Add(new AutocompleteItem() { Text = Words.LEFT_JOIN, MenuText = "LEFT JOIN", ImageIndex = (int)FinalImageIndex.LeftJoin });
            list.Add(new AutocompleteItem() { Text = Words.RIGHT_JOIN, MenuText = "RIGHT JOIN", ImageIndex = (int)FinalImageIndex.RightJoin });
            list.Add(new AutocompleteItem(Words.FULL_OUTER_JOIN)
            {
                Text = Words.FULL_OUTER_JOIN,
                MenuText = "OUTER",
                ImageIndex = (int)FinalImageIndex.OuterJoin
            });
            return list;
        }

        // contains non related user db and user tables, info commands
        // like sql keyword, pl sql words
        internal static List<AutocompleteItem> GetAllDbCommands()
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            list.AddRange(JoinCommands());
            list.AddRange(PlSqlCommands());
            list.AddRange(SqlCommands());
            return list;
        }

        internal static List<AutocompleteItem> CreateTableItems(List<string> tables)
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            foreach (string t in tables)
            {
                list.Add(new AutocompleteItem(t) { ImageIndex = (int)FinalImageIndex.Table });
            }
            return list;
        }

        internal static List<AutocompleteItem> CreateFieldItems(List<Table> fields)
        {
            List<AutocompleteItem> list = new List<AutocompleteItem>();
            foreach (Table t in fields)
            {
                list.Add(new AutocompleteItem()
                {
                    ImageIndex = (int)FinalImageIndex.Field,
                    MenuText = t.TableName + "." + t.ColumnName,
                    Text = t.ColumnName
                });
            }
            return list;
        }
    }
}
