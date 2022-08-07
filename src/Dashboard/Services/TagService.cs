using Dashboard.Models.Tags;

namespace Dashboard.Services
{
    internal static class TagService
    {
        public static List<NoteTag> translateTags(string tags)
        {
            var tagCollection = tags.Split("\n");
            var convertedTags = tagCollection
                .Select(tag =>
                {
                    if (!tag.StartsWith('<') || !tag.EndsWith('>'))
                    {
                        return null;
                    }

                    return TagService.translateTag(tag);
                })
                .Where(tag => tag != null)
                .ToList();

            return convertedTags!;
        }

        public static NoteTag translateTag(string tag)
        {
            if (tag.Contains(':'))
            {
                var split = tag.Split(':');
                var name = split[0].TrimStart('<');
                var value = split[1].Trim().TrimEnd('>');
                var notetag = new NoteTag { Name = name, Value = value };
                return translateNameValueTag(tag);
            }
            else
            {
                var nameAndValue = tag.TrimStart('<').TrimEnd('>');
                var notetag = new NoteTag { Name = nameAndValue, Value = nameAndValue };
                return notetag;
            }
        }

        private static NoteTag translateNameValueTag(string tag)
        {
            var split = tag.Split(':');
            var name = split[0].TrimStart('<');
            var value = split[1].Trim().TrimEnd('>');
            var notetag = new NoteTag { Name = name, Value = value };
            return notetag;
        }
    }
}
