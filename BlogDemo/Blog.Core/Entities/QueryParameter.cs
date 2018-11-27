using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Blog.Core.Interface;

namespace Blog.Core.Entities
{
    public abstract class QueryParameter:INotifyPropertyChanged
    {
        private const int DefaultPageSize = 10;
        private const int DefaultMaxPageSize = 100;

        /// <summary>
        /// 当前页
        /// </summary>
        private int _pageIndex;
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value > 0 ? value : 0;
        }

        /// <summary>
        /// 分页大小
        /// </summary>
        private int _pageSize = DefaultPageSize;

        public virtual int PageSize
        {
            get => _pageSize;
            set => SetFiels(ref _pageSize,value);
        }

        /// <summary>
        /// 最大分页大小
        /// </summary>
        private int _maxPageSize = DefaultMaxPageSize;

        protected internal virtual int MaxPageSize
        {
            get => _maxPageSize;
            set => SetFiels(ref _maxPageSize, value);
        }
       
        /// <summary>
        /// 排序
        /// </summary>
        private string _orderBy;

        public string OrderBy
        {
            get => _orderBy;
            set => _orderBy=value ?? nameof(Entity.Id);
        }

        public string Fields { get; set; }

        protected bool SetFiels<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            if (propertyName == nameof(PageSize) || propertyName == nameof(MaxPageSize))
            {
                SetPageSize();
            }
            return true;
        }

        private void SetPageSize()
        {
            if (_maxPageSize < 0)
            {
                _maxPageSize = DefaultMaxPageSize;
            }

            if (_pageSize <= 0)
            {
                _pageSize = DefaultPageSize;
            }
            //分页大小不能大于指定最大分页大小
            _pageSize = _pageSize > _maxPageSize ? _maxPageSize : _pageSize;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}