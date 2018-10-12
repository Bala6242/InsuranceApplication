using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Dtos
{
    public interface IResponseDto
    {
        bool IsSuccess { get; }
        List<ErrorCode> ErrorCodes { get; set; }
        MessageCode MessageCode { get; set; }
        void Reset();
    }

    public class ResponseDto : IResponseDto
    {
        public ResponseDto()
        {
            ErrorCodes = new List<ErrorCode>();
        }

        public bool IsSuccess
        {
            get
            {
                return ErrorCodes == null || ErrorCodes.Count == 0;
            }
        }

      //  [JsonIgnore]
        public MessageCode MessageCode { get; set; }

        //[JsonIgnore]
        public List<ErrorCode> ErrorCodes { get; set; }

        public string Message
        {
            get
            {
                if (IsSuccess && MessageCode != null)
                    return MessageCode.Message;
                else if (!IsSuccess && ErrorCodes != null && ErrorCodes.Count > 0)
                    return string.Join(", ", ErrorCodes.Select(x => x.Message));
                return string.Empty;
            }
        }

        public virtual void Reset()
        {
        }
    }

    public class ResponseDto<T> : ResponseDto
    {
        public ResponseDto()
        {
            Result = default(T);
        }

        public ResponseDto(T result)
        {
            Result = result;
        }

        public T Result { get; set; }

        public override void Reset()
        {
            base.Reset();
            Result = default(T);
        }
    }
}
