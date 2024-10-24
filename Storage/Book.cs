using System;
using BookCat.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookCat.Storage
{ 
    [Serializable]
    public class Book
    {
        [JsonInclude]
        private string _title;
        [JsonInclude]
        private int _year;
        [JsonInclude]
        private string _author;
        [JsonInclude]
        private string _isbn;
        [JsonInclude]
        private string _annotation;
        
        // it's important to use HashSet to store tokens. The main reason is quick Contains check 
        [JsonInclude]
        private HashSet<string> _genres = [];
        private HashSet<string> _annotationTokens = [];
        private HashSet<string> _nameTokens = [];
        private HashSet<string> _authorNameTokens = [];

        // necessary to match parameters and constructor names for JSON deserialization
        [JsonConstructor]
        public Book(string _title, int _year, string _author, string _isbn, string _annotation,
            HashSet<string> _genres)
        {
            this._title = _title.Trim();
            this._year = _year;
            this._author = _author.Trim();
            this._isbn = _isbn.Trim();
            this._annotation = _annotation.Trim();
            this._genres = _genres.ToHashSet();
            Tokenizator.Tokenize(_annotationTokens, _annotation);
            Tokenizator.Tokenize(_nameTokens, _title);
            Tokenizator.Tokenize(_authorNameTokens, _author);
        }
        public Book(string title, int year, string author, string isbn, string annotation, string genres)
        {
            _title = title.Trim();
            _year = year;
            _author = author.Trim();
            _isbn = isbn.Trim();
            _annotation = annotation.Trim();
            Tokenizator.Tokenize(_annotationTokens, _annotation);
            Tokenizator.Tokenize(_nameTokens, _title);
            Tokenizator.Tokenize(_genres, genres);
            Tokenizator.Tokenize(_authorNameTokens, _author);
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Book Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Book>(json);
        }
        public string GetIsbn()
        {
            return _isbn;
        }
        
        public string GetTitle()
        {
            return _title;
        }
        
        public string GetAuthor()
        {
            return _author;
        }
        
        public string GetAnnotation()
        {
            return _annotation;
        }

        public int? GetYear()
        {
            return _year;
        }

        public bool FindAuthor(string author)
        {
            HashSet<string> name = [];
            Tokenizator.Tokenize(name, author.ToLowerInvariant());

            foreach (var part in name)
            {
                if (!_authorNameTokens.Contains(part))
                {
                    return false;
                }
            }

            return true;
        }
        public bool FindTitle(string keyword)
        {
            return _nameTokens.Contains(keyword.ToLowerInvariant());
        }
        
        public bool FindGenres(string keyword)
        {
            return _genres.Contains(keyword.ToLowerInvariant());
        }
        
        public bool FindKeywordInAnnotation(string keyword)
        {
            return _annotationTokens.Contains(keyword.ToLowerInvariant());
        }

        public string GetBriefInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var g in _genres)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }

                sb.Append(g);
            }
            
            return $"{_title}, {_author}, {sb}, {_year}, ISBN: {_isbn}";
        }
    }
}