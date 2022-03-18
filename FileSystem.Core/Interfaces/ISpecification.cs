using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Core.Interfaces
{
    public interface ISpecification<T, TResult> : ISpecification<T>
    { 
        Expression<Func<T, TResult>> Selector { get; }

        new Func<IEnumerable<TResult>, IEnumerable<TResult>>? PostProcessingAction { get; }

        new IEnumerable<TResult> Evaluate(IEnumerable<T> entities);
    }

    public interface ISpecification<T>
    {
        //IEnumerable<WhereExpressionInfo<T>> WhereExpressions { get; }
    }
}
